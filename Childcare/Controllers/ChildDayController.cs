using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Childcare.Models;

namespace Childcare.Controllers
{
    public class ChildDayController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChildDay
        public ActionResult Index()
        {
            var childDays = db.ChildDays.Include(c => c.Child);
            
            return View(childDays.ToList());
        }

        // GET: ChildDay/Details/5
        public ActionResult Details(short? id, string day)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days dayno = (Days)Enum.Parse(typeof(Days), day, true);

            ChildDay childDay = db.ChildDays.Find(id, dayno);

            if (childDay == null)
            {
                return HttpNotFound();
            }
            return View(childDay);
        }

        // GET: ChildDay/Create
        public ActionResult Create()
        {
            ViewBag.childid = new SelectList(db.Children, "childid", "childname");
            return View();
        }

        // POST: ChildDay/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "childid,Day")] ChildDay childDay)
        {
            if (ModelState.IsValid)
            {
                db.ChildDays.Add(childDay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childDay.childid);
            return View(childDay);
        }

        // GET: ChildDay/Edit/5
        public ActionResult Edit(short? id, string day)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days dayno  = (Days)Enum.Parse(typeof(Days), day, true);
        
            ChildDay childDay = db.ChildDays.Find(id, dayno);
            if (childDay == null)
            {
                return HttpNotFound();
            }
            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childDay.childid);
            return View(childDay);
        }

        // POST: ChildDay/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "childid,Day")] ChildDay childDay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childDay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childDay.childid);
            return View(childDay);
        }

        // GET: ChildDay/Delete/5
        public ActionResult Delete(short? id, string day)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Days dayno = (Days)Enum.Parse(typeof(Days), day, true);
            ChildDay childDay = db.ChildDays.Find(id, dayno);
            if (childDay == null)
            {
                return HttpNotFound();
            }
            return View(childDay);
        }

        // POST: ChildDay/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id, string day)
        {
            Days dayno = (Days)Enum.Parse(typeof(Days), day, true);
            ChildDay childDay = db.ChildDays.Find(id, dayno);
            db.ChildDays.Remove(childDay);
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
