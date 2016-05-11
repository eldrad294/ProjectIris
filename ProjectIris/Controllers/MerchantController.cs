using ProjectIris.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using ProjectIris.Utils;

namespace ProjectIris.Controllers
{
    public class MerchantController : Controller
    {
        private Entities db = new Entities();

        // GET: Merchant
        [HttpGet]
        public ActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Purchase([Bind(Include = "total, discount, subtotal, iriscode")] MerchantViewModel mvm)
        {
            if (ModelState.IsValid)
            {
                HttpPostedFileBase file = Request.Files["iriscode"];
                if (file != null && file.ContentLength > 0)
                {
                    try
                    {
                        //Saving Image tempolary on the server
                        string path = Path.Combine(Server.MapPath("~/Content/img/irisimages"), Path.GetFileName(file.FileName));
                        file.SaveAs(path);

                        //Executing Iris EncodingScript
                        string clientid = EncoderFactory.RecognizeIris(file.FileName, db);

                        //Deleting tempolary image from the server
                        FileInfo f = new FileInfo(Server.MapPath("~/Content/img/irisimages/") + Path.GetFileName(file.FileName));
                        f.Delete();

                        if (clientid == "")
                        {
                            ModelState.AddModelError("","Iris Image not recognized. Client not found!");
                            return View(mvm);
                        }

                        TempData["subtotal"] = mvm.subtotal;
                        return RedirectToAction("Confirmation", "Merchant", new { clientid = clientid });
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Message = "ERROR:" + ex.Message.ToString();
                    }
                }
            }
            return View(mvm);
        }

        [HttpGet]
        // GET: accounts
        public async Task<ActionResult> Confirmation(string clientid)
        {
            return View(await db.accounts.Where(x => x.client.clientidnumber == clientid).ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> FinalConfirmation(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            account account = await db.accounts.FindAsync(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FinalConfirmation([Bind(Include = "id,clientid,accountnumber,accounttype,bankid,iban,pin,balance")]account account)
        {
            if (ModelState.IsValid)
            {
                //Update Account Balance
                decimal DeductedBalance = Decimal.Parse(TempData["subtotal"].ToString());
                if (account == null)
                {
                    return HttpNotFound();
                }
                account.balance -= DeductedBalance;
                db.Entry(account).State = EntityState.Modified;

                //Creating Log Entry
                db.purchases_log.Add(new purchases_log(1, DateTime.Now, User.Identity.GetUserId(), DeductedBalance, account.accountnumber, "PAYMENT SUCCESSFUL"));

                //SMS Confirmation
                client client = await db.clients.FindAsync(account.clientid);
                SMS.SMSConfirmation(client.lname, DeductedBalance.ToString(), account.accountnumber);

                await db.SaveChangesAsync();
                return RedirectToAction("Index", "purchases_log", new { area = "" });
            }

            return View(account);
        }
    }
}