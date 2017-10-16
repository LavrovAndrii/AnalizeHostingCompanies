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
    public class SpeedConnectionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SpeedConnections
        public async Task<ActionResult> Index()
        {
            return View(await db.SpeedConnections.ToListAsync());
        }

        // GET: SpeedConnections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeedConnection speedConnection = await db.SpeedConnections.FindAsync(id);
            if (speedConnection == null)
            {
                return HttpNotFound();
            }
            return View(speedConnection);
        }

        // GET: SpeedConnections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SpeedConnections/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NameSpeed,Price")] SpeedConnection speedConnection)
        {
            if (ModelState.IsValid)
            {
                db.SpeedConnections.Add(speedConnection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(speedConnection);
        }

        // GET: SpeedConnections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeedConnection speedConnection = await db.SpeedConnections.FindAsync(id);
            if (speedConnection == null)
            {
                return HttpNotFound();
            }
            return View(speedConnection);
        }

        // POST: SpeedConnections/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NameSpeed,Price")] SpeedConnection speedConnection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(speedConnection).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(speedConnection);
        }

        // GET: SpeedConnections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SpeedConnection speedConnection = await db.SpeedConnections.FindAsync(id);
            if (speedConnection == null)
            {
                return HttpNotFound();
            }
            return View(speedConnection);
        }

        // POST: SpeedConnections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SpeedConnection speedConnection = await db.SpeedConnections.FindAsync(id);
            db.SpeedConnections.Remove(speedConnection);
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
