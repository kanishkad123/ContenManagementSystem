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
    public class FAQController : Controller
    {
        private CompanyContext db = new CompanyContext();

        // GET: FAQ
        public ActionResult Index(string Category)
        {
            ViewBag.CategorySelected = false;
            var faqs = from q in db.faqs select q;
            ViewBag.Categories = faqs.Select(q => new { q.Category }).Distinct();

            if (!String.IsNullOrEmpty(Category))
            {
                ViewBag.CategorySelected = true;
                faqs = faqs.Where(q => q.Category.Equals(Category));
            }
            return View(faqs.ToList());
        }

        // GET: FAQ/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            if (frequentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(frequentQuestion);
        }

        // GET: FAQ/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FAQ/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FrequentQuestionID,Question,Answer")] FrequentQuestion frequentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.faqs.Add(frequentQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(frequentQuestion);
        }

        // GET: FAQ/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            if (frequentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(frequentQuestion);
        }

        // POST: FAQ/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FrequentQuestionID,Question,Answer")] FrequentQuestion frequentQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frequentQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(frequentQuestion);
        }

        // GET: FAQ/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            if (frequentQuestion == null)
            {
                return HttpNotFound();
            }
            return View(frequentQuestion);
        }

        // POST: FAQ/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FrequentQuestion frequentQuestion = db.faqs.Find(id);
            db.faqs.Remove(frequentQuestion);
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
