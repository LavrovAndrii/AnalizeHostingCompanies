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
    public class IpAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: IpAddresses
        public async Task<ActionResult> Index()
        {
            return View(await db.IpAddresses.ToListAsync());
        }

        // GET: IpAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpAddress ipAddress = await db.IpAddresses.FindAsync(id);
            if (ipAddress == null)
            {
                return HttpNotFound();
            }
            return View(ipAddress);
        }

        // GET: IpAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IpAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NameIpAddress,Price")] IpAddress ipAddress)
        {
            if (ModelState.IsValid)
            {
                db.IpAddresses.Add(ipAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(ipAddress);
        }

        // GET: IpAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpAddress ipAddress = await db.IpAddresses.FindAsync(id);
            if (ipAddress == null)
            {
                return HttpNotFound();
            }
            return View(ipAddress);
        }

        // POST: IpAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NameIpAddress,Price")] IpAddress ipAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ipAddress);
        }

        // GET: IpAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpAddress ipAddress = await db.IpAddresses.FindAsync(id);
            if (ipAddress == null)
            {
                return HttpNotFound();
            }
            return View(ipAddress);
        }

        // POST: IpAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            IpAddress ipAddress = await db.IpAddresses.FindAsync(id);
            db.IpAddresses.Remove(ipAddress);
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
