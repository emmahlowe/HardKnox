using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HardKnock.DAL;
using HardKnock.Models;

namespace HardKnock.Controllers
{
    public class MajorsController : Controller
    {
        private HardKnoxContext db = new HardKnoxContext();

        // GET: Majors
        public ActionResult Index()
        {
            return View(db.Major.ToList());
        }

        // GET: Majors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majors majors = db.Major.Find(id);
            if (majors == null)
            {
                return HttpNotFound();
            }
            return View(majors);
        }

        // GET: Majors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Majors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]//prevends Cross Site Scripting Attacks
        public ActionResult Create([Bind(Include = "Major_ID,Major_Description")] Majors majors)
        {
            if (ModelState.IsValid)
            {
                db.Major.Add(majors);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(majors);
        }

        // GET: Majors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majors majors = db.Major.Find(id);
            if (majors == null)
            {
                return HttpNotFound();
            }
            return View(majors);
        }

        // POST: Majors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Major_ID,Major_Description")] Majors majors)
        {
            if (ModelState.IsValid)
            {
                db.Entry(majors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(majors);
        }

        // GET: Majors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Majors majors = db.Major.Find(id);
            if (majors == null)
            {
                return HttpNotFound();
            }
            return View(majors);
        }

        // POST: Majors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Majors majors = db.Major.Find(id);
            db.Major.Remove(majors);
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
