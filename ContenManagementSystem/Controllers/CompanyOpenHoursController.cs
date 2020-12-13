using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContenManagementSystem.DAL;
using ContenManagementSystem.Models;

namespace ContenManagementSystem.Controllers
{
    public class CompanyOpenHoursController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: CompanyOpenHours
        public ActionResult Index()
        {
            return View(db.OpenHours.ToList());
        }

        // GET: CompanyOpenHours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            if (companyOpenHours == null)
            {
                return HttpNotFound();
            }
            return View(companyOpenHours);
        }

        // GET: CompanyOpenHours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyOpenHours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyOpenHoursID,mondayOpen,mondayClose,tuesdayOpen,tuesdayClose,wednesdayOpen,wednesdayClose,thursdayOpen,thursdayClose,fridayOpen,fridayClose,saturdayOpen,saturdayClose,sundayOpen,sundayClose")] CompanyOpenHours companyOpenHours)
        {
            if (ModelState.IsValid)
            {
                db.OpenHours.Add(companyOpenHours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyOpenHours);
        }

        // GET: CompanyOpenHours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            if (companyOpenHours == null)
            {
                return HttpNotFound();
            }
            return View(companyOpenHours);
        }

        // POST: CompanyOpenHours/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyOpenHoursID,mondayOpen,mondayClose,tuesdayOpen,tuesdayClose,wednesdayOpen,wednesdayClose,thursdayOpen,thursdayClose,fridayOpen,fridayClose,saturdayOpen,saturdayClose,sundayOpen,sundayClose")] CompanyOpenHours companyOpenHours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyOpenHours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyOpenHours);
        }

        // GET: CompanyOpenHours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            if (companyOpenHours == null)
            {
                return HttpNotFound();
            }
            return View(companyOpenHours);
        }

        // POST: CompanyOpenHours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyOpenHours companyOpenHours = db.OpenHours.Find(id);
            db.OpenHours.Remove(companyOpenHours);
            db.SaveChanges();
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
