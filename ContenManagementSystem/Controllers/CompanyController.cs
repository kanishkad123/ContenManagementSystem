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
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.CompanyDescClasses.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyDescClassID,ShortDesc,Address,Website,Telephone")] CompanyDescClass companyDescClass)
        {
            if (ModelState.IsValid)
            {
                db.CompanyDescClasses.Add(companyDescClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyDescClass);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyDescClassID,ShortDesc,Address,Website,Telephone")] CompanyDescClass companyDescClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyDescClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyDescClass);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            if (companyDescClass == null)
            {
                return HttpNotFound();
            }
            return View(companyDescClass);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyDescClass companyDescClass = db.CompanyDescClasses.Find(id);
            db.CompanyDescClasses.Remove(companyDescClass);
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
