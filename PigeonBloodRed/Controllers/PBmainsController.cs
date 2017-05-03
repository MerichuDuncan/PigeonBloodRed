using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PigeonBloodRed.Models;

namespace PigeonBloodRed.Controllers
{
    public class PBmainsController : Controller
    {
        private PigeonBloodRedContext db = new PigeonBloodRedContext();

        // GET: PBmains
        public ActionResult Index()
        {
            return View(db.PBmains.ToList());
        }

        // GET: PBmains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBmain pBmain = db.PBmains.Find(id);
            if (pBmain == null)
            {
                return HttpNotFound();
            }
            return View(pBmain);
        }

        // GET: PBmains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PBmains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EdID,Chapters,Date,Content,Profile")] PBmain pBmain)
        {
            if (ModelState.IsValid)
            {
                db.PBmains.Add(pBmain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pBmain);
        }

        // GET: PBmains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBmain pBmain = db.PBmains.Find(id);
            if (pBmain == null)
            {
                return HttpNotFound();
            }
            return View(pBmain);
        }

        // POST: PBmains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EdID,Chapters,Date,Content,Profile")] PBmain pBmain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pBmain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pBmain);
        }

        // GET: PBmains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PBmain pBmain = db.PBmains.Find(id);
            if (pBmain == null)
            {
                return HttpNotFound();
            }
            return View(pBmain);
        }

        // POST: PBmains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PBmain pBmain = db.PBmains.Find(id);
            db.PBmains.Remove(pBmain);
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
