using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectIris.Models;

namespace ProjectIris.Controllers
{
    [Authorize(Roles = "Admin,ClientManager")]
    public class accounts_logController : Controller
    {
        private Entities db = new Entities();

        // GET: accounts_log
        public async Task<ActionResult> Index()
        {
            return View(await db.accounts_log.ToListAsync());
        }

        // GET: accounts_log/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounts_log accounts_log = await db.accounts_log.FindAsync(id);
            if (accounts_log == null)
            {
                return HttpNotFound();
            }
            return View(accounts_log);
        }

        // GET: accounts_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: accounts_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,datecreated,accountnumber,message")] accounts_log accounts_log)
        {
            if (ModelState.IsValid)
            {
                db.accounts_log.Add(accounts_log);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(accounts_log);
        }

        // GET: accounts_log/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounts_log accounts_log = await db.accounts_log.FindAsync(id);
            if (accounts_log == null)
            {
                return HttpNotFound();
            }
            return View(accounts_log);
        }

        // POST: accounts_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,datecreated,accountnumber,message")] accounts_log accounts_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accounts_log).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(accounts_log);
        }

        // GET: accounts_log/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            accounts_log accounts_log = await db.accounts_log.FindAsync(id);
            if (accounts_log == null)
            {
                return HttpNotFound();
            }
            return View(accounts_log);
        }

        // POST: accounts_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            accounts_log accounts_log = await db.accounts_log.FindAsync(id);
            db.accounts_log.Remove(accounts_log);
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
    }
}
