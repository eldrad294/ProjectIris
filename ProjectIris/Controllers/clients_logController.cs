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
    public class clients_logController : Controller
    {
        private Entities db = new Entities();

        // GET: clients_log
        public async Task<ActionResult> Index()
        {
            return View(await db.clients_log.OrderByDescending(s => s.id).ToListAsync());
        }

        // GET: clients_log/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients_log clients_log = await db.clients_log.FindAsync(id);
            if (clients_log == null)
            {
                return HttpNotFound();
            }
            return View(clients_log);
        }

        // GET: clients_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: clients_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,datecreated,clientidnumber,message")] clients_log clients_log)
        {
            if (ModelState.IsValid)
            {
                db.clients_log.Add(clients_log);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(clients_log);
        }

        // GET: clients_log/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients_log clients_log = await db.clients_log.FindAsync(id);
            if (clients_log == null)
            {
                return HttpNotFound();
            }
            return View(clients_log);
        }

        // POST: clients_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,datecreated,clientidnumber,message")] clients_log clients_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clients_log).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(clients_log);
        }

        // GET: clients_log/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            clients_log clients_log = await db.clients_log.FindAsync(id);
            if (clients_log == null)
            {
                return HttpNotFound();
            }
            return View(clients_log);
        }

        // POST: clients_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            clients_log clients_log = await db.clients_log.FindAsync(id);
            db.clients_log.Remove(clients_log);
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
