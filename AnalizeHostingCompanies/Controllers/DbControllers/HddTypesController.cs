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
    public class HddTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HddTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.HddTypes.ToListAsync());
        }

        // GET: HddTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddType hddType = await db.HddTypes.FindAsync(id);
            if (hddType == null)
            {
                return HttpNotFound();
            }
            return View(hddType);
        }

        // GET: HddTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HddTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] HddType hddType)
        {
            if (ModelState.IsValid)
            {
                db.HddTypes.Add(hddType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(hddType);
        }

        // GET: HddTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddType hddType = await db.HddTypes.FindAsync(id);
            if (hddType == null)
            {
                return HttpNotFound();
            }
            return View(hddType);
        }

        // POST: HddTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] HddType hddType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hddType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(hddType);
        }

        // GET: HddTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HddType hddType = await db.HddTypes.FindAsync(id);
            if (hddType == null)
            {
                return HttpNotFound();
            }
            return View(hddType);
        }

        // POST: HddTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HddType hddType = await db.HddTypes.FindAsync(id);
            db.HddTypes.Remove(hddType);
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
