using System;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectIris.Models;
using System.IO;
using System.Diagnostics;
using ProjectIris.Utils;
using System.Data.Entity.Validation;

namespace ProjectIris.Controllers
{
    [Authorize(Roles = "Admin,ClientManager")]
    public class clientsController : Controller
    {
        private Entities db = new Entities();
        private Enums en = new Enums();

        // GET: clients
        public async Task<ActionResult> Index()
        {
            return View(await db.clients.ToListAsync());
        }

        // GET: clients/Details/5
        public async Task<ActionResult> Details(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = await db.clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: clients/Create
        public ActionResult Create()
        {
            ViewBag.Titles = en.TitleDropDowns();
            ViewBag.MarriedStatus = en.MarriedStatusDropDowns();
            ViewBag.Countries = en.CountriesDropDowns();
            ViewBag.Employment = en.EmploymentDropDowns();
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,clientidnumber,iriscode,title,fname,lname,ssnumber,dateofbirth,maritalstatus,employment,emailaddress,residentaddress,country,postcode")] client client)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        HttpPostedFileBase file = Request.Files["iriscode"];
        //        if (file != null && file.ContentLength > 0)
        //        {
        //            try
        //            {
        //                //Saving Image tempolary on the server
        //                string path = Path.Combine(Server.MapPath("~/Content/img/irisimages"), Path.GetFileName(file.FileName));
        //                file.SaveAs(path);

        //                //Executing Iris EncodingScript
        //                client.iriscode = EncoderFactory.EncodeIris(file.FileName);

        //                //Deleting tempolary image from the server
        //                FileInfo f = new FileInfo(Server.MapPath("~/Content/img/irisimages/") + Path.GetFileName(file.FileName));
        //                f.Delete();

        //                db.clients.Add(client);
        //                //Creating Log Entry
        //                db.clients_log.Add(new clients_log(1, DateTime.Now, client.clientidnumber, "CLIENT CREATED"));
        //                db.SaveChangesAsync();
        //                return RedirectToAction("Index");
        //            }
        //            catch (DbEntityValidationException dbEx)
        //            {
        //                ViewBag.Message = dbEx.ToString();
        //                foreach (var validationErrors in dbEx.EntityValidationErrors)
        //                {
        //                    foreach (var validationError in validationErrors.ValidationErrors)
        //                    {
        //                        Trace.TraceInformation("Property: {0} Error: {1}",
        //                                                validationError.PropertyName,
        //                                                validationError.ErrorMessage);
        //                    }
        //                }
        //            }
        //        }
        //    }

        //    ViewBag.Titles = en.TitleDropDowns();
        //    ViewBag.MarriedStatus = en.MarriedStatusDropDowns();
        //    ViewBag.Countries = en.CountriesDropDowns();
        //    ViewBag.Employment = en.EmploymentDropDowns();
        //    return View(client);
        //}

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormCollection form)
        {
            client client = new client();
            //if (ModelState.IsValid)
            // {
            client.id = Int32.Parse(form["id"]);
            client.clientidnumber = form["clientidnumber"];
            client.title = form["title"];
            client.fname = form["fname"];
            client.lname = form["lname"];
            client.ssnumber = form["ssnumber"];
            client.dateofbirth = DateTime.Parse(form["dateofbirth"]);
            client.maritalstatus = form["maritalstatus"];
            client.employment = form["employment"];
            client.emailaddress = form["emailaddress"];
            client.residentaddress = form["residentaddress"];
            client.country = form["country"];
            client.postcode = form["postcode"];
            HttpPostedFileBase file = Request.Files["iriscode"];
            if (file != null && file.ContentLength > 0)
            {
                try
                {
                    //Saving Image tempolary on the server
                    string path = Path.Combine(Server.MapPath("~/Content/img/irisimages"), Path.GetFileName(file.FileName));
                    file.SaveAs(path);

                    //Executing Iris EncodingScript
                    client.iriscode = EncoderFactory.EncodeIris(file.FileName);
                    //client.iriscode = "KATA";

                    //Deleting tempolary image from the server
                    FileInfo f = new FileInfo(Server.MapPath("~/Content/img/irisimages/") + Path.GetFileName(file.FileName));
                    f.Delete();

                    db.clients.Add(client);
                    //Creating Log Entry
                    db.clients_log.Add(new clients_log(1, DateTime.Now, client.clientidnumber, "CLIENT CREATED"));
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                catch (DbEntityValidationException dbEx)
                {
                    ViewBag.Message = dbEx.ToString();
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
            }
            //}

            ViewBag.Titles = en.TitleDropDowns();
            ViewBag.MarriedStatus = en.MarriedStatusDropDowns();
            ViewBag.Countries = en.CountriesDropDowns();
            ViewBag.Employment = en.EmploymentDropDowns();
            return View(client);
        }


        // GET: clients/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = await db.clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.Titles = en.TitleDropDowns();
            ViewBag.MarriedStatus = en.MarriedStatusDropDowns();
            ViewBag.Countries = en.CountriesDropDowns();
            ViewBag.Employment = en.EmploymentDropDowns();
            ViewBag.titl = client.title;
            ViewBag.status = client.maritalstatus;
            ViewBag.country = client.country;
            ViewBag.employ = client.employment;
            return View(client);
        }

        // POST: clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,clientidnumber,iriscode,title,fname,lname,ssnumber,dateofbirth,maritalstatus,employment,emailaddress,residentaddress,country,postcode")] client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                //Creating Log Entry
                db.clients_log.Add(new clients_log(1, DateTime.Now, client.clientidnumber, "CLIENT UPDATED"));
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Titles = en.TitleDropDowns();
            ViewBag.MarriedStatus = en.MarriedStatusDropDowns();
            ViewBag.Countries = en.CountriesDropDowns();
            ViewBag.Employment = en.EmploymentDropDowns();
            ViewBag.titl = client.title;
            ViewBag.status = client.maritalstatus;
            ViewBag.country = client.country;
            ViewBag.employ = client.employment;
            return View(client);
        }

        // GET: clients/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            client client = await db.clients.FindAsync(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            client client = await db.clients.FindAsync(id);
            //Creating Log Entry
            db.clients_log.Add(new clients_log(1, DateTime.Now, client.clientidnumber, "CLIENT DELETED"));
            db.clients.Remove(client);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //private string CompressCode(string iriscode)
        //{
        //    string CompressedCode = "";
        //    for(int i = 0; i < iriscode.Length; i++)
        //    {
        //        CompressCode += 
        //    }
        //}
    }
}
