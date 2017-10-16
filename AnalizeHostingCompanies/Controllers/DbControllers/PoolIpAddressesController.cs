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
    public class PoolIpAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PoolIpAddresses
        public async Task<ActionResult> Index()
        {
            return View(await db.PoolIpAddresses.ToListAsync());
        }

        // GET: PoolIpAddresses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoolIpAddress poolIpAddress = await db.PoolIpAddresses.FindAsync(id);
            if (poolIpAddress == null)
            {
                return HttpNotFound();
            }
            return View(poolIpAddress);
        }

        // GET: PoolIpAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PoolIpAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,IpNetwork,CountIpAddress,Mask")] PoolIpAddress poolIpAddress)
        {
            if (ModelState.IsValid)
            {
                db.PoolIpAddresses.Add(poolIpAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(poolIpAddress);
        }

        // GET: PoolIpAddresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoolIpAddress poolIpAddress = await db.PoolIpAddresses.FindAsync(id);
            if (poolIpAddress == null)
            {
                return HttpNotFound();
            }
            return View(poolIpAddress);
        }

        // POST: PoolIpAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,IpNetwork,CountIpAddress,Mask")] PoolIpAddress poolIpAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(poolIpAddress).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(poolIpAddress);
        }

        // GET: PoolIpAddresses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PoolIpAddress poolIpAddress = await db.PoolIpAddresses.FindAsync(id);
            if (poolIpAddress == null)
            {
                return HttpNotFound();
            }
            return View(poolIpAddress);
        }

        // POST: PoolIpAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PoolIpAddress poolIpAddress = await db.PoolIpAddresses.FindAsync(id);
            db.PoolIpAddresses.Remove(poolIpAddress);
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
