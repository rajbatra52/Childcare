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
    public class AllUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AllUsers
        public ActionResult Index()
        {
            return View(db.AllUsers.ToList());
        }

        // GET: AllUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUsers allUsers = db.AllUsers.Find(id);
            if (allUsers == null)
            {
                return HttpNotFound();
            }
            return View(allUsers);
        }

        // GET: AllUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userid,password,username")] AllUsers allUsers)
        {
            if (ModelState.IsValid)
            {
                db.AllUsers.Add(allUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(allUsers);
        }

        // GET: AllUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUsers allUsers = db.AllUsers.Find(id);
            if (allUsers == null)
            {
                return HttpNotFound();
            }
            return View(allUsers);
        }

        // POST: AllUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "userid,password,username")] AllUsers allUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(allUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(allUsers);
        }

        // GET: AllUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AllUsers allUsers = db.AllUsers.Find(id);
            if (allUsers == null)
            {
                return HttpNotFound();
            }
            return View(allUsers);
        }

        // POST: AllUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AllUsers allUsers = db.AllUsers.Find(id);
            db.AllUsers.Remove(allUsers);
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
