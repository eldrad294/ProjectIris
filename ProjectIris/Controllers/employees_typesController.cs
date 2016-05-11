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
using Microsoft.AspNet.Identity.EntityFramework;

namespace ProjectIris.Controllers
{
    [Authorize(Roles = "Admin,EmployeeManager")]
    public class employees_typesController : Controller
    {
        private Entities db = new Entities();

        // GET: employees_types
        public async Task<ActionResult> Index()
        {
            return View(await db.AspNetRoles.ToListAsync());
        }

        // GET: employees_types/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole employees_types = await db.AspNetRoles.FindAsync(id);
            if (employees_types == null)
            {
                return HttpNotFound();
            }
            return View(employees_types);
        }

        //// GET: employees_types/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: employees_types/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "id,name")] AspNetRole employees_types)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.AspNetRoles.Add(employees_types);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(employees_types);
        //}

        // GET: employees_types/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole employees_types = await db.AspNetRoles.FindAsync(id);
            if (employees_types == null)
            {
                return HttpNotFound();
            }
            return View(employees_types);
        }

        // POST: employees_types/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name")] AspNetRole employees_types)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employees_types).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(employees_types);
        }

        // GET: employees_types/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetRole employees_types = await db.AspNetRoles.FindAsync(id);
            if (employees_types == null)
            {
                return HttpNotFound();
            }
            return View(employees_types);
        }

        // POST: employees_types/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            AspNetRole employees_types = await db.AspNetRoles.FindAsync(id);
            db.AspNetRoles.Remove(employees_types);
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
