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
    public class ChildController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Child
        public ActionResult Index()
        {
            //var Children = from c in db.Children orderby c.childdob  descending select c ;//Linq statement
            var Children = db.Children.OrderByDescending(m=>m.childid).ThenBy(m=>m.childdob).ToList();
            return View(Children);
        }

        // GET: Child/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // GET: Child/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Child/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "childid,childname,childdob,childaddress,childgender")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Children.Add(child);
                db.SaveChanges();  
                ViewBag.message = "This child has been added successfully";
                return View();
            }

            return View(child);
        }

        // GET: Child/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Child/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "childid,childname,childdob,childaddress,childgender")] Child child)
        {
            if (ModelState.IsValid)
            {
                db.Entry(child).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(child);
        }

        // GET: Child/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Child child = db.Children.Find(id);
            if (child == null)
            {
                return HttpNotFound();
            }
            return View(child);
        }

        // POST: Child/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            Child child = db.Children.Find(id);
            db.Children.Remove(child);
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
