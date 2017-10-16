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
    public class CpuTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CpuTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.CpuTypes.ToListAsync());
        }

        // GET: CpuTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuType cpuType = await db.CpuTypes.FindAsync(id);
            if (cpuType == null)
            {
                return HttpNotFound();
            }
            return View(cpuType);
        }

        // GET: CpuTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CpuTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name")] CpuType cpuType)
        {
            if (ModelState.IsValid)
            {
                db.CpuTypes.Add(cpuType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(cpuType);
        }

        // GET: CpuTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuType cpuType = await db.CpuTypes.FindAsync(id);
            if (cpuType == null)
            {
                return HttpNotFound();
            }
            return View(cpuType);
        }

        // POST: CpuTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name")] CpuType cpuType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cpuType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(cpuType);
        }

        // GET: CpuTypes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CpuType cpuType = await db.CpuTypes.FindAsync(id);
            if (cpuType == null)
            {
                return HttpNotFound();
            }
            return View(cpuType);
        }

        // POST: CpuTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CpuType cpuType = await db.CpuTypes.FindAsync(id);
            db.CpuTypes.Remove(cpuType);
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
