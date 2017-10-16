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
    public class InternetProvidersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: InternetProviders
        public async Task<ActionResult> Index()
        {
            var internetProviders = db.InternetProviders.Include(i => i.SpeedConnection).Include(i => i.Traffic);
            return View(await internetProviders.ToListAsync());
        }

        // GET: InternetProviders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetProvider internetProvider = await db.InternetProviders.FindAsync(id);
            if (internetProvider == null)
            {
                return HttpNotFound();
            }
            return View(internetProvider);
        }

        // GET: InternetProviders/Create
        public ActionResult Create()
        {
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id");
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id");
            return View();
        }

        // POST: InternetProviders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,SpeedConnectionId,TrafficId,PoolIpAddressId,Ping,MaxSpeed,MaxTraffic")] InternetProvider internetProvider)
        {
            if (ModelState.IsValid)
            {
                db.InternetProviders.Add(internetProvider);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", internetProvider.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", internetProvider.TrafficId);
            return View(internetProvider);
        }

        // GET: InternetProviders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetProvider internetProvider = await db.InternetProviders.FindAsync(id);
            if (internetProvider == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", internetProvider.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", internetProvider.TrafficId);
            return View(internetProvider);
        }

        // POST: InternetProviders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,SpeedConnectionId,TrafficId,PoolIpAddressId,Ping,MaxSpeed,MaxTraffic")] InternetProvider internetProvider)
        {
            if (ModelState.IsValid)
            {
                db.Entry(internetProvider).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", internetProvider.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", internetProvider.TrafficId);
            return View(internetProvider);
        }

        // GET: InternetProviders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InternetProvider internetProvider = await db.InternetProviders.FindAsync(id);
            if (internetProvider == null)
            {
                return HttpNotFound();
            }
            return View(internetProvider);
        }

        // POST: InternetProviders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            InternetProvider internetProvider = await db.InternetProviders.FindAsync(id);
            db.InternetProviders.Remove(internetProvider);
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
