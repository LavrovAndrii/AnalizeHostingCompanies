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
    public class PhisicalServersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PhisicalServers
        public async Task<ActionResult> Index()
        {
            var phisicalServers = db.PhisicalServers.Include(p => p.CpuType).Include(p => p.HddType).Include(p => p.VirtualServer);
            return View(await phisicalServers.ToListAsync());
        }

        // GET: PhisicalServers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhisicalServer phisicalServer = await db.PhisicalServers.FindAsync(id);
            if (phisicalServer == null)
            {
                return HttpNotFound();
            }
            return View(phisicalServer);
        }

        // GET: PhisicalServers/Create
        public ActionResult Create()
        {
            ViewBag.CpuTypeId = new SelectList(db.CpuTypes, "Id", "Name");
            ViewBag.HddTypeId = new SelectList(db.HddTypes, "Id", "Name");
            ViewBag.VirtualServerId = new SelectList(db.VirtualServers, "Id", "NameTypeServer");
            return View();
        }

        // POST: PhisicalServers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,CpuTypeId,HddTypeId,VirtualServerId,CountCpuCores,CountHdd,CountRam,CpuMax,HddMax,RamMax,PowerConsumptionMax")] PhisicalServer phisicalServer)
        {
            if (ModelState.IsValid)
            {
                db.PhisicalServers.Add(phisicalServer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CpuTypeId = new SelectList(db.CpuTypes, "Id", "Name", phisicalServer.CpuTypeId);
            ViewBag.HddTypeId = new SelectList(db.HddTypes, "Id", "Name", phisicalServer.HddTypeId);
            ViewBag.VirtualServerId = new SelectList(db.VirtualServers, "Id", "NameTypeServer", phisicalServer.VirtualServerId);
            return View(phisicalServer);
        }

        // GET: PhisicalServers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhisicalServer phisicalServer = await db.PhisicalServers.FindAsync(id);
            if (phisicalServer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CpuTypeId = new SelectList(db.CpuTypes, "Id", "Name", phisicalServer.CpuTypeId);
            ViewBag.HddTypeId = new SelectList(db.HddTypes, "Id", "Name", phisicalServer.HddTypeId);
            ViewBag.VirtualServerId = new SelectList(db.VirtualServers, "Id", "NameTypeServer", phisicalServer.VirtualServerId);
            return View(phisicalServer);
        }

        // POST: PhisicalServers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,CpuTypeId,HddTypeId,VirtualServerId,CountCpuCores,CountHdd,CountRam,CpuMax,HddMax,RamMax,PowerConsumptionMax")] PhisicalServer phisicalServer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phisicalServer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CpuTypeId = new SelectList(db.CpuTypes, "Id", "Name", phisicalServer.CpuTypeId);
            ViewBag.HddTypeId = new SelectList(db.HddTypes, "Id", "Name", phisicalServer.HddTypeId);
            ViewBag.VirtualServerId = new SelectList(db.VirtualServers, "Id", "NameTypeServer", phisicalServer.VirtualServerId);
            return View(phisicalServer);
        }

        // GET: PhisicalServers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhisicalServer phisicalServer = await db.PhisicalServers.FindAsync(id);
            if (phisicalServer == null)
            {
                return HttpNotFound();
            }
            return View(phisicalServer);
        }

        // POST: PhisicalServers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PhisicalServer phisicalServer = await db.PhisicalServers.FindAsync(id);
            db.PhisicalServers.Remove(phisicalServer);
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
