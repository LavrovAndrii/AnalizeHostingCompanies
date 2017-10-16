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
    public class HostingCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: HostingCompanies
        public async Task<ActionResult> Index()
        {
            var hostingCompanies = db.HostingCompanies.Include(h => h.InternetProvider).Include(h => h.Location).Include(h => h.ServerDataCenter).Include(h => h.Staff);
            return View(await hostingCompanies.ToListAsync());
        }

        // GET: HostingCompanies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingCompany hostingCompany = await db.HostingCompanies.FindAsync(id);
            if (hostingCompany == null)
            {
                return HttpNotFound();
            }
            return View(hostingCompany);
        }

        // GET: HostingCompanies/Create
        public ActionResult Create()
        {
            ViewBag.InternetProviderId = new SelectList(db.InternetProviders, "Id", "Name");
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "City");
            ViewBag.ServerDataCenterId = new SelectList(db.ServerDataCenters, "Id", "Name");
            ViewBag.StuffId = new SelectList(db.Staves, "Id", "Name");
            return View();
        }

        // POST: HostingCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,LocationId,Site,InternetProviderId,ServerDataCenterId,StuffId")] HostingCompany hostingCompany)
        {
            if (ModelState.IsValid)
            {
                db.HostingCompanies.Add(hostingCompany);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.InternetProviderId = new SelectList(db.InternetProviders, "Id", "Name", hostingCompany.InternetProviderId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "City", hostingCompany.LocationId);
            ViewBag.ServerDataCenterId = new SelectList(db.ServerDataCenters, "Id", "Name", hostingCompany.ServerDataCenterId);
            ViewBag.StuffId = new SelectList(db.Staves, "Id", "Name", hostingCompany.StuffId);
            return View(hostingCompany);
        }

        // GET: HostingCompanies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingCompany hostingCompany = await db.HostingCompanies.FindAsync(id);
            if (hostingCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.InternetProviderId = new SelectList(db.InternetProviders, "Id", "Name", hostingCompany.InternetProviderId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "City", hostingCompany.LocationId);
            ViewBag.ServerDataCenterId = new SelectList(db.ServerDataCenters, "Id", "Name", hostingCompany.ServerDataCenterId);
            ViewBag.StuffId = new SelectList(db.Staves, "Id", "Name", hostingCompany.StuffId);
            return View(hostingCompany);
        }

        // POST: HostingCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LocationId,Site,InternetProviderId,ServerDataCenterId,StuffId")] HostingCompany hostingCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hostingCompany).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.InternetProviderId = new SelectList(db.InternetProviders, "Id", "Name", hostingCompany.InternetProviderId);
            ViewBag.LocationId = new SelectList(db.Locations, "Id", "City", hostingCompany.LocationId);
            ViewBag.ServerDataCenterId = new SelectList(db.ServerDataCenters, "Id", "Name", hostingCompany.ServerDataCenterId);
            ViewBag.StuffId = new SelectList(db.Staves, "Id", "Name", hostingCompany.StuffId);
            return View(hostingCompany);
        }

        // GET: HostingCompanies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HostingCompany hostingCompany = await db.HostingCompanies.FindAsync(id);
            if (hostingCompany == null)
            {
                return HttpNotFound();
            }
            return View(hostingCompany);
        }

        // POST: HostingCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            HostingCompany hostingCompany = await db.HostingCompanies.FindAsync(id);
            db.HostingCompanies.Remove(hostingCompany);
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
