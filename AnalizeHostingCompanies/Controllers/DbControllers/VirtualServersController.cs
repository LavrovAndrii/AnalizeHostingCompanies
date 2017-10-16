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
    public class VirtualServersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VirtualServers
        public async Task<ActionResult> Index()
        {
            var virtualServers = db.VirtualServers.Include(v => v.Cms).Include(v => v.CountCpuCore).Include(v => v.HddVirtual).Include(v => v.IpAddress).Include(v => v.OfferPeriod).Include(v => v.PriceVirtual).Include(v => v.RamVirtual).Include(v => v.SpeedConnection).Include(v => v.Traffic);
            return View(await virtualServers.ToListAsync());
        }

        // GET: VirtualServers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualServer virtualServer = await db.VirtualServers.FindAsync(id);
            if (virtualServer == null)
            {
                return HttpNotFound();
            }
            return View(virtualServer);
        }

        // GET: VirtualServers/Create
        public ActionResult Create()
        {
            ViewBag.CmsId = new SelectList(db.Cmses, "Id", "Name");
            ViewBag.CountCpuCoreId = new SelectList(db.CountCpuCores, "Id", "Id");
            ViewBag.HddVirtualId = new SelectList(db.HddVirtuals, "Id", "Id");
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "NameIpAddress");
            ViewBag.OfferPeriodId = new SelectList(db.OfferPeriods, "Id", "Id");
            ViewBag.PriceVirtualId = new SelectList(db.PriceVirtuals, "Id", "Id");
            ViewBag.RamVirtualId = new SelectList(db.RamVirtuals, "Id", "Id");
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id");
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id");
            return View();
        }

        // POST: VirtualServers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,NameTypeServer,CmsId,PriceVirtualId,MaxCountRequest,CountCpuCoreId,HddVirtualId,RamVirtualId,IpAddressId,TrafficId,SpeedConnectionId,OfferPeriodId")] VirtualServer virtualServer)
        {
            if (ModelState.IsValid)
            {
                db.VirtualServers.Add(virtualServer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CmsId = new SelectList(db.Cmses, "Id", "Name", virtualServer.CmsId);
            ViewBag.CountCpuCoreId = new SelectList(db.CountCpuCores, "Id", "Id", virtualServer.CountCpuCoreId);
            ViewBag.HddVirtualId = new SelectList(db.HddVirtuals, "Id", "Id", virtualServer.HddVirtualId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "NameIpAddress", virtualServer.IpAddressId);
            ViewBag.OfferPeriodId = new SelectList(db.OfferPeriods, "Id", "Id", virtualServer.OfferPeriodId);
            ViewBag.PriceVirtualId = new SelectList(db.PriceVirtuals, "Id", "Id", virtualServer.PriceVirtualId);
            ViewBag.RamVirtualId = new SelectList(db.RamVirtuals, "Id", "Id", virtualServer.RamVirtualId);
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", virtualServer.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", virtualServer.TrafficId);
            return View(virtualServer);
        }

        // GET: VirtualServers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualServer virtualServer = await db.VirtualServers.FindAsync(id);
            if (virtualServer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CmsId = new SelectList(db.Cmses, "Id", "Name", virtualServer.CmsId);
            ViewBag.CountCpuCoreId = new SelectList(db.CountCpuCores, "Id", "Id", virtualServer.CountCpuCoreId);
            ViewBag.HddVirtualId = new SelectList(db.HddVirtuals, "Id", "Id", virtualServer.HddVirtualId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "NameIpAddress", virtualServer.IpAddressId);
            ViewBag.OfferPeriodId = new SelectList(db.OfferPeriods, "Id", "Id", virtualServer.OfferPeriodId);
            ViewBag.PriceVirtualId = new SelectList(db.PriceVirtuals, "Id", "Id", virtualServer.PriceVirtualId);
            ViewBag.RamVirtualId = new SelectList(db.RamVirtuals, "Id", "Id", virtualServer.RamVirtualId);
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", virtualServer.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", virtualServer.TrafficId);
            return View(virtualServer);
        }

        // POST: VirtualServers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,NameTypeServer,CmsId,PriceVirtualId,MaxCountRequest,CountCpuCoreId,HddVirtualId,RamVirtualId,IpAddressId,TrafficId,SpeedConnectionId,OfferPeriodId")] VirtualServer virtualServer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(virtualServer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CmsId = new SelectList(db.Cmses, "Id", "Name", virtualServer.CmsId);
            ViewBag.CountCpuCoreId = new SelectList(db.CountCpuCores, "Id", "Id", virtualServer.CountCpuCoreId);
            ViewBag.HddVirtualId = new SelectList(db.HddVirtuals, "Id", "Id", virtualServer.HddVirtualId);
            ViewBag.IpAddressId = new SelectList(db.IpAddresses, "Id", "NameIpAddress", virtualServer.IpAddressId);
            ViewBag.OfferPeriodId = new SelectList(db.OfferPeriods, "Id", "Id", virtualServer.OfferPeriodId);
            ViewBag.PriceVirtualId = new SelectList(db.PriceVirtuals, "Id", "Id", virtualServer.PriceVirtualId);
            ViewBag.RamVirtualId = new SelectList(db.RamVirtuals, "Id", "Id", virtualServer.RamVirtualId);
            ViewBag.SpeedConnectionId = new SelectList(db.SpeedConnections, "Id", "Id", virtualServer.SpeedConnectionId);
            ViewBag.TrafficId = new SelectList(db.Traffics, "Id", "Id", virtualServer.TrafficId);
            return View(virtualServer);
        }

        // GET: VirtualServers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VirtualServer virtualServer = await db.VirtualServers.FindAsync(id);
            if (virtualServer == null)
            {
                return HttpNotFound();
            }
            return View(virtualServer);
        }

        // POST: VirtualServers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VirtualServer virtualServer = await db.VirtualServers.FindAsync(id);
            db.VirtualServers.Remove(virtualServer);
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
