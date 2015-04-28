using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectChore_Application;

namespace ProjectChore_Application.Controllers
{
    public class ChoreLookUpsController : Controller
    {
        private ProjectChoresDBEntities db = new ProjectChoresDBEntities();

        // GET: ChoreLookUps
        public ActionResult Index()
        {
            var choreLookUps = db.ChoreLookUps.Include(c => c.Chore).Include(c => c.Kid);
            return View(choreLookUps.ToList());
        }

        // GET: ChoreLookUps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreLookUp choreLookUp = db.ChoreLookUps.Find(id);
            if (choreLookUp == null)
            {
                return HttpNotFound();
            }
            return View(choreLookUp);
        }

        // GET: ChoreLookUps/Create
        public ActionResult Create()
        {
            ViewBag.ChoreId = new SelectList(db.Chores, "ChoreId", "Description");
            ViewBag.KidId = new SelectList(db.Kids, "KidId", "FirstName");
            return View();
        }

        // POST: ChoreLookUps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChoreLookUpId,DateCompleted,DateAssigned,Active,KidId,ChoreId")] ChoreLookUp choreLookUp)
        {
            if (ModelState.IsValid)
            {
                db.ChoreLookUps.Add(choreLookUp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChoreId = new SelectList(db.Chores, "ChoreId", "Description", choreLookUp.ChoreId);
            ViewBag.KidId = new SelectList(db.Kids, "KidId", "FirstName", choreLookUp.KidId);
            return View(choreLookUp);
        }

        // GET: ChoreLookUps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreLookUp choreLookUp = db.ChoreLookUps.Find(id);
            if (choreLookUp == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChoreId = new SelectList(db.Chores, "ChoreId", "Description", choreLookUp.ChoreId);
            ViewBag.KidId = new SelectList(db.Kids, "KidId", "FirstName", choreLookUp.KidId);
            return View(choreLookUp);
        }

        // POST: ChoreLookUps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChoreLookUpId,DateCompleted,DateAssigned,Active,KidId,ChoreId")] ChoreLookUp choreLookUp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(choreLookUp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChoreId = new SelectList(db.Chores, "ChoreId", "Description", choreLookUp.ChoreId);
            ViewBag.KidId = new SelectList(db.Kids, "KidId", "FirstName", choreLookUp.KidId);
            return View(choreLookUp);
        }

        // GET: ChoreLookUps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChoreLookUp choreLookUp = db.ChoreLookUps.Find(id);
            if (choreLookUp == null)
            {
                return HttpNotFound();
            }
            return View(choreLookUp);
        }

        // POST: ChoreLookUps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChoreLookUp choreLookUp = db.ChoreLookUps.Find(id);
            db.ChoreLookUps.Remove(choreLookUp);
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
