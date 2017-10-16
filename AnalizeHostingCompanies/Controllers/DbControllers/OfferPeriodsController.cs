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
    public class OfferPeriodsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OfferPeriods
        public async Task<ActionResult> Index()
        {
            return View(await db.OfferPeriods.ToListAsync());
        }

        // GET: OfferPeriods/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferPeriod offerPeriod = await db.OfferPeriods.FindAsync(id);
            if (offerPeriod == null)
            {
                return HttpNotFound();
            }
            return View(offerPeriod);
        }

        // GET: OfferPeriods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OfferPeriods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,CountDay,StartData")] OfferPeriod offerPeriod)
        {
            if (ModelState.IsValid)
            {
                db.OfferPeriods.Add(offerPeriod);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(offerPeriod);
        }

        // GET: OfferPeriods/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferPeriod offerPeriod = await db.OfferPeriods.FindAsync(id);
            if (offerPeriod == null)
            {
                return HttpNotFound();
            }
            return View(offerPeriod);
        }

        // POST: OfferPeriods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,CountDay,StartData")] OfferPeriod offerPeriod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(offerPeriod).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(offerPeriod);
        }

        // GET: OfferPeriods/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OfferPeriod offerPeriod = await db.OfferPeriods.FindAsync(id);
            if (offerPeriod == null)
            {
                return HttpNotFound();
            }
            return View(offerPeriod);
        }

        // POST: OfferPeriods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OfferPeriod offerPeriod = await db.OfferPeriods.FindAsync(id);
            db.OfferPeriods.Remove(offerPeriod);
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
