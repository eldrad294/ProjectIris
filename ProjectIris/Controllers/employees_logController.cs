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
    [Authorize(Roles = "Admin,EmployeeManager")]
    public class employees_logController : Controller
    {
        private Entities db = new Entities();

        // GET: employees_log
        public async Task<ActionResult> Index()
        {
            return View(await db.employees_log.OrderByDescending(s => s.id).ToListAsync());
        }

        // GET: employees_log/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_log employees_log = await db.employees_log.FindAsync(id);
            if (employees_log == null)
            {
                return HttpNotFound();
            }
            return View(employees_log);
        }

        // GET: employees_log/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees_log/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,datecreated,employeeid,message")] employees_log employees_log)
        {
            if (ModelState.IsValid)
            {
                db.employees_log.Add(employees_log);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(employees_log);
        }

        // GET: employees_log/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_log employees_log = await db.employees_log.FindAsync(id);
            if (employees_log == null)
            {
                return HttpNotFound();
            }
            return View(employees_log);
        }

        // POST: employees_log/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,datecreated,employeeid,message")] employees_log employees_log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees_log).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employees_log);
        }

        // GET: employees_log/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employees_log employees_log = await db.employees_log.FindAsync(id);
            if (employees_log == null)
            {
                return HttpNotFound();
            }
            return View(employees_log);
        }

        // POST: employees_log/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            employees_log employees_log = await db.employees_log.FindAsync(id);
            db.employees_log.Remove(employees_log);
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
