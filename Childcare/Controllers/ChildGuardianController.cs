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
    public class ChildGuardianController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ChildGuardian
        public ActionResult Index()
        {
            var childGuardians = db.ChildGuardians.Include(c => c.Child).Include(c => c.Guardian).OrderBy(c=>c.childid).ThenByDescending(c=>c.Guardian.guardianrelationship);
            return View(childGuardians.ToList());
        }

        // GET: ChildGuardian/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildGuardian childGuardian = db.ChildGuardians.Find(id);
            if (childGuardian == null)
            {
                return HttpNotFound();
            }
            return View(childGuardian);
        }

        // GET: ChildGuardian/Create
        public ActionResult Create()
        {
            ViewBag.childid = new SelectList(db.Children, "childid", "childname");
            ViewBag.guardianid = new SelectList(db.Guardians, "guardianid", "guardianname");
            return View();
        }

        // POST: ChildGuardian/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "childid,guardianid")] ChildGuardian childGuardian)
        {
            if (ModelState.IsValid)
            {
                db.ChildGuardians.Add(childGuardian);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childGuardian.childid);
            ViewBag.guardianid = new SelectList(db.Guardians, "guardianid", "guardianname", childGuardian.guardianid);
            return View(childGuardian);
        }

        // GET: ChildGuardian/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildGuardian childGuardian = db.ChildGuardians.Find(id);
            if (childGuardian == null)
            {
                return HttpNotFound();
            }
            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childGuardian.childid);
            ViewBag.guardianid = new SelectList(db.Guardians, "guardianid", "guardianname", childGuardian.guardianid);
            return View(childGuardian);
        }

        // POST: ChildGuardian/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "childid,guardianid")] ChildGuardian childGuardian)
        {
            if (ModelState.IsValid)
            {
                db.Entry(childGuardian).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.childid = new SelectList(db.Children, "childid", "childname", childGuardian.childid);
            ViewBag.guardianid = new SelectList(db.Guardians, "guardianid", "guardianname", childGuardian.guardianid);
            return View(childGuardian);
        }

        // GET: ChildGuardian/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChildGuardian childGuardian = db.ChildGuardians.Find(id);
            if (childGuardian == null)
            {
                return HttpNotFound();
            }
            return View(childGuardian);
        }

        // POST: ChildGuardian/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            ChildGuardian childGuardian = db.ChildGuardians.Find(id);
            db.ChildGuardians.Remove(childGuardian);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChildGuardians()
        {
            //var childguardians = db.ChildGuardians.Include(c => c.Child).Include(c => c.Guardian).OrderBy(c => c.childid);
            //return View(childguardians.ToList());

            IEnumerable<ChildGuardian> childguardian = (from cg in db.ChildGuardians
                                                        join ch in db.Children on cg.childid equals ch.childid
                                                        join c in db.Guardians on cg.guardianid equals c.guardianid
                                                        select new { cg, ch, c }) as IEnumerable<ChildGuardian>;
            return View(childguardian);
            
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
