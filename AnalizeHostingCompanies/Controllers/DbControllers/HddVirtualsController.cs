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
    public class HddVirtualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HddVirtuals
        public async Task<ActionResult> Index()
        {
            return View(await db.HddVirtuals.ToListAsync());
        }

        // GET: HddVirtuals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddVirtual hddVirtual = await db.HddVirtuals.FindAsync(id);
            if (hddVirtual == null)
            {
                return HttpNotFound();
            }
            return View(hddVirtual);
        }

        // GET: HddVirtuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HddVirtuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,HddMemory")] HddVirtual hddVirtual)
        {
            if (ModelState.IsValid)
            {
                db.HddVirtuals.Add(hddVirtual);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hddVirtual);
        }

        // GET: HddVirtuals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddVirtual hddVirtual = await db.HddVirtuals.FindAsync(id);
            if (hddVirtual == null)
            {
                return HttpNotFound();
            }
            return View(hddVirtual);
        }

        // POST: HddVirtuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,HddMemory")] HddVirtual hddVirtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hddVirtual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hddVirtual);
        }

        // GET: HddVirtuals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddVirtual hddVirtual = await db.HddVirtuals.FindAsync(id);
            if (hddVirtual == null)
            {
                return HttpNotFound();
            }
            return View(hddVirtual);
        }

        // POST: HddVirtuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HddVirtual hddVirtual = await db.HddVirtuals.FindAsync(id);
            db.HddVirtuals.Remove(hddVirtual);
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
