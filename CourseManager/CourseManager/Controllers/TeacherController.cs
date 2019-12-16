using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CourseManager.Models;

namespace CourseManager.Controllers
{
    public class TeacherController : Controller
    {
        private CourseManagerEntities db = new CourseManagerEntities();

        // GET: Teacher
        public ActionResult Index()
        {
            return View(db.TeacherId.ToList());
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherId teacherId = db.TeacherId.Find(id);
            if (teacherId == null)
            {
                return HttpNotFound();
            }
            return View(teacherId);
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] TeacherId teacherId)
        {
            if (ModelState.IsValid)
            {
                db.TeacherId.Add(teacherId);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teacherId);
        }

        // GET: Teacher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherId teacherId = db.TeacherId.Find(id);
            if (teacherId == null)
            {
                return HttpNotFound();
            }
            return View(teacherId);
        }

        // POST: Teacher/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] TeacherId teacherId)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teacherId).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teacherId);
        }

        // GET: Teacher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeacherId teacherId = db.TeacherId.Find(id);
            if (teacherId == null)
            {
                return HttpNotFound();
            }
            return View(teacherId);
        }

        // POST: Teacher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeacherId teacherId = db.TeacherId.Find(id);
            db.TeacherId.Remove(teacherId);
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
