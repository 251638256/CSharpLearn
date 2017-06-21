using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 控制器入门.Models;

namespace 控制器入门.Controllers
{
    public class 基本信息Controller : Controller
    {
        private Model db = new Model();

        // GET: 基本信息
        public ActionResult Index()
        {
            return View(db.基本信息.ToList());
        }

        // GET: 基本信息/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            基本信息 基本信息 = db.基本信息.Find(id);
            if (基本信息 == null)
            {
                return HttpNotFound();
            }
            return View(基本信息);
        }

        // GET: 基本信息/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: 基本信息/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,姓名,性别,年龄")] 基本信息 基本信息)
        {
            if (ModelState.IsValid)
            {
                db.基本信息.Add(基本信息);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(基本信息);
        }

        // GET: 基本信息/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            基本信息 基本信息 = db.基本信息.Find(id);
            if (基本信息 == null)
            {
                return HttpNotFound();
            }
            return View(基本信息);
        }

        // POST: 基本信息/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,姓名,性别,年龄")] 基本信息 基本信息)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(基本信息).State = EntityState.Modified;
                //db.基本信
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(基本信息);
        }

        // GET: 基本信息/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            基本信息 基本信息 = db.基本信息.Find(id);
            if (基本信息 == null)
            {
                return HttpNotFound();
            }
            return View(基本信息);
        }

        // POST: 基本信息/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            基本信息 基本信息 = db.基本信息.Find(id);
            db.基本信息.Remove(基本信息);
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
