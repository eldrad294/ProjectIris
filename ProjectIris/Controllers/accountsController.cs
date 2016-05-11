using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ProjectIris.Models;
using System;

namespace ProjectIris.Controllers
{
    [Authorize(Roles = "Admin,ClientManager")]
    public class accountsController : Controller
    {
        private Entities db = new Entities();
        private Enums en = new Enums();

        // GET: accounts
        public async Task<ActionResult> Index()
        {
            return View(await db.accounts.ToListAsync());
        }

        // GET: accounts/Details/5
        public async Task<ActionResult> Details(int? id)
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

        // GET: accounts/Create
        public ActionResult Create()
        {
            ViewBag.clientid = new SelectList(db.clients, "id", "clientidnumber");
            ViewBag.bankid = new SelectList(db.banks, "id", "bankname");
            ViewBag.swiftcode = new SelectList(db.banks, "id", "swiftcode");
            ViewBag.branchcode = new SelectList(db.banks, "id", "branchcode");
            ViewBag.AccountTypes = en.AccountTypesDropDowns();
            account account = new account();
            account.accountnumber = generateAccountNumber();
            account.pin = generatePIN();
            return View(account);
        }

        // POST: accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,clientid,accountnumber,accounttype,bankid,iban,pin,balance")] account account)
        {
            account.client = await db.clients.FindAsync(account.clientid);
            account.bank = await db.banks.FindAsync(account.bankid);
            if (ModelState.IsValid)
            {
                db.accounts.Add(account);
                //Creating Log Entry
                db.accounts_log.Add(new accounts_log(0, DateTime.Now, account.accountnumber, "ACCOUNT CREATED"));
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.clients = new SelectList(db.clients, "id", "clientidnumber");
            ViewBag.bankname = new SelectList(db.banks, "id", "bankname");
            ViewBag.swiftcode = new SelectList(db.banks, "id", "swiftcode");
            ViewBag.branchcode = new SelectList(db.banks, "id", "branchcode");
            ViewBag.AccountTypes = en.AccountTypesDropDowns();
            account.accountnumber = generateAccountNumber();
            account.pin = generatePIN();
            return View(account);
        }

        //// GET: accounts/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    account account = await db.accounts.FindAsync(id);
        //    if (account == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.AccountTypes = en.AccountTypesDropDowns();
        //    ViewBag.accounttype = account.accounttype;
        //    return View(account);
        //}

        //// POST: accounts/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "id,clientid,accountnumber,accounttype,bankid,iban,pin")] account account)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(account).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.AccountTypes = en.AccountTypesDropDowns();
        //    ViewBag.accounttype = account.accounttype;
        //    return View(account);
        //}

        // GET: accounts/Delete/5
        public async Task<ActionResult> Delete(int? id)
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

        // POST: accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            account account = await db.accounts.FindAsync(id);
            db.accounts.Remove(account);
            //Creating Log Entry
            db.accounts_log.Add(new accounts_log(0, DateTime.Now, account.accountnumber, "ACCOUNT DELETED"));
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

        private string generateAccountNumber()
        {
            Random rnd = new Random();
            string accountnumber = "";
            for(int i = 0; i < 18; i++)
            {
                accountnumber += rnd.Next(0, 9);
            }
            return accountnumber;
        }

        private string generatePIN()
        {
            Random rnd = new Random();
            string PIN = "";
            for (int i = 0; i < 4; i++)
            {
                PIN += rnd.Next(0, 9);
            }
            return PIN;
        }
    }
}
