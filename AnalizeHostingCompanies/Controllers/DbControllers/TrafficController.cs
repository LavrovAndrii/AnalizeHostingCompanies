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
    public class TrafficController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Traffic
        public async Task<ActionResult> Index()
        {
            return View(await db.Traffics.ToListAsync());
        }

        // GET: Traffic/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic traffic = await db.Traffics.FindAsync(id);
            if (traffic == null)
            {
                return HttpNotFound();
            }
            return View(traffic);
        }

        // GET: Traffic/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Traffic/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Data,Price")] Traffic traffic)
        {
            if (ModelState.IsValid)
            {
                db.Traffics.Add(traffic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(traffic);
        }

        // GET: Traffic/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic traffic = await db.Traffics.FindAsync(id);
            if (traffic == null)
            {
                return HttpNotFound();
            }
            return View(traffic);
        }

        // POST: Traffic/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Data,Price")] Traffic traffic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(traffic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(traffic);
        }

        // GET: Traffic/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Traffic traffic = await db.Traffics.FindAsync(id);
            if (traffic == null)
            {
                return HttpNotFound();
            }
            return View(traffic);
        }

        // POST: Traffic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Traffic traffic = await db.Traffics.FindAsync(id);
            db.Traffics.Remove(traffic);
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
