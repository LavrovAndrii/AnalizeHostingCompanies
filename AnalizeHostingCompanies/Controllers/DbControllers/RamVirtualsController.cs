using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AnalizeHostingCompanies.Models;
using AnalizeHostingCompanies.Models.DbEntities;

namespace AnalizeHostingCompanies.Controllers.DbControllers
{
    public class RamVirtualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RamVirtuals
        public async Task<ActionResult> Index()
        {
            return View(await db.RamVirtuals.ToListAsync());
        }

        // GET: RamVirtuals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamVirtual ramVirtual = await db.RamVirtuals.FindAsync(id);
            if (ramVirtual == null)
            {
                return HttpNotFound();
            }
            return View(ramVirtual);
        }

        // GET: RamVirtuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RamVirtuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,RamMemory")] RamVirtual ramVirtual)
        {
            if (ModelState.IsValid)
            {
                db.RamVirtuals.Add(ramVirtual);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ramVirtual);
        }

        // GET: RamVirtuals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamVirtual ramVirtual = await db.RamVirtuals.FindAsync(id);
            if (ramVirtual == null)
            {
                return HttpNotFound();
            }
            return View(ramVirtual);
        }

        // POST: RamVirtuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,RamMemory")] RamVirtual ramVirtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ramVirtual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ramVirtual);
        }

        // GET: RamVirtuals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RamVirtual ramVirtual = await db.RamVirtuals.FindAsync(id);
            if (ramVirtual == null)
            {
                return HttpNotFound();
            }
            return View(ramVirtual);
        }

        // POST: RamVirtuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RamVirtual ramVirtual = await db.RamVirtuals.FindAsync(id);
            db.RamVirtuals.Remove(ramVirtual);
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
