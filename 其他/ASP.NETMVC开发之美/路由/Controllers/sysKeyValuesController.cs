using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 路由.Models;

namespace 路由.Controllers
{
    public class sysKeyValuesController : Controller
    {
        private JKCRMEntities db = new JKCRMEntities();

        // GET: sysKeyValues
        public ActionResult Index()
        {
            //db.sysKeyValue.Include(c => c.wfWorkNodes1)
            return View(db.sysKeyValue.ToList());
        }

        // GET: sysKeyValues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysKeyValue sysKeyValue = db.sysKeyValue.Find(id);
            if (sysKeyValue == null)
            {
                return HttpNotFound();
            }
            return View(sysKeyValue);
        }

        // GET: sysKeyValues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sysKeyValues/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KID,ParentID,KType,KName,Kvalue,KRemark")] sysKeyValue sysKeyValue)
        {
            if (ModelState.IsValid)
            {
                db.sysKeyValue.Add(sysKeyValue);
                db.SaveChanges();
                return RedirectToAction("Index");
            } else {
                ModelState.AddModelError("", "出大事额");
            }

            return View(sysKeyValue);
        }



        // GET: sysKeyValues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysKeyValue sysKeyValue = db.sysKeyValue.Find(id);
            if (sysKeyValue == null)
            {
                return HttpNotFound();
            }
            return View(sysKeyValue);
        }

        // POST: sysKeyValues/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KID,ParentID,KType,KName,Kvalue,KRemark")] sysKeyValue sysKeyValue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysKeyValue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysKeyValue);
        }

        // GET: sysKeyValues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysKeyValue sysKeyValue = db.sysKeyValue.Find(id);
            if (sysKeyValue == null)
            {
                return HttpNotFound();
            }
            return View(sysKeyValue);
        }

        // POST: sysKeyValues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sysKeyValue sysKeyValue = db.sysKeyValue.Find(id);
            db.sysKeyValue.Remove(sysKeyValue);
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
