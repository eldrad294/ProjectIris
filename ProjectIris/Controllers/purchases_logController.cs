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
    public class purchases_logController : Controller
    {
        private Entities db = new Entities();

        // GET: purchases_log
        public async Task<ActionResult> Index()
        {
            return View(await db.purchases_log.ToListAsync());
        }

        // GET: purchases_log/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchases_log purchases_log = await db.purchases_log.FindAsync(id);
            if (purchases_log == null)
            {
                return HttpNotFound();
            }
            return View(purchases_log);
        }

        // GET: purchases_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: purchases_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,dateofpurchase,employeeid,amount,accountnumber,message")] purchases_log purchases_log)
        {
            if (ModelState.IsValid)
            {
                db.purchases_log.Add(purchases_log);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(purchases_log);
        }

        // GET: purchases_log/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchases_log purchases_log = await db.purchases_log.FindAsync(id);
            if (purchases_log == null)
            {
                return HttpNotFound();
            }
            return View(purchases_log);
        }

        // POST: purchases_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,dateofpurchase,employeeid,amount,accountnumber,message")] purchases_log purchases_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(purchases_log).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(purchases_log);
        }

        // GET: purchases_log/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            purchases_log purchases_log = await db.purchases_log.FindAsync(id);
            if (purchases_log == null)
            {
                return HttpNotFound();
            }
            return View(purchases_log);
        }

        // POST: purchases_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            purchases_log purchases_log = await db.purchases_log.FindAsync(id);
            db.purchases_log.Remove(purchases_log);
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
