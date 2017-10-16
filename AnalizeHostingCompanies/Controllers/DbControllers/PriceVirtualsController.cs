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
    public class PriceVirtualsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PriceVirtuals
        public async Task<ActionResult> Index()
        {
            return View(await db.PriceVirtuals.ToListAsync());
        }

        // GET: PriceVirtuals/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceVirtual priceVirtual = await db.PriceVirtuals.FindAsync(id);
            if (priceVirtual == null)
            {
                return HttpNotFound();
            }
            return View(priceVirtual);
        }

        // GET: PriceVirtuals/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PriceVirtuals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,PricePerDay")] PriceVirtual priceVirtual)
        {
            if (ModelState.IsValid)
            {
                db.PriceVirtuals.Add(priceVirtual);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(priceVirtual);
        }

        // GET: PriceVirtuals/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceVirtual priceVirtual = await db.PriceVirtuals.FindAsync(id);
            if (priceVirtual == null)
            {
                return HttpNotFound();
            }
            return View(priceVirtual);
        }

        // POST: PriceVirtuals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,PricePerDay")] PriceVirtual priceVirtual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(priceVirtual).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(priceVirtual);
        }

        // GET: PriceVirtuals/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PriceVirtual priceVirtual = await db.PriceVirtuals.FindAsync(id);
            if (priceVirtual == null)
            {
                return HttpNotFound();
            }
            return View(priceVirtual);
        }

        // POST: PriceVirtuals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PriceVirtual priceVirtual = await db.PriceVirtuals.FindAsync(id);
            db.PriceVirtuals.Remove(priceVirtual);
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
