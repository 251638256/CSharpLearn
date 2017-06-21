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
    public class sysUserInfoesController : Controller
    {
        private JKCRMEntities db = new JKCRMEntities();

        // GET: sysUserInfoes
        public ActionResult Index()
        {
            var sysUserInfo = db.sysUserInfo.Include(s => s.sysOrganStruct).Include(s => s.sysOrganStruct1).Include(s => s.sysOrganStruct2);
            return View(sysUserInfo.ToList());
        }

        // GET: sysUserInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysUserInfo sysUserInfo = db.sysUserInfo.Find(id);
            if (sysUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(sysUserInfo);
        }

        // GET: sysUserInfoes/Create
        public ActionResult Create()
        {
            ViewBag.uCompanyID = new SelectList(db.sysOrganStruct, "osID", "osName");
            ViewBag.uDepID = new SelectList(db.sysOrganStruct, "osID", "osName");
            ViewBag.uWorkGroupID = new SelectList(db.sysOrganStruct, "osID", "osName");
            return View();
        }

        // POST: sysUserInfoes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "uID,uLoginName,uLoginPWD,uRealName,uTelphone,uMobile,uEmial,uQQ,uGender,uStatus,uCompanyID,uDepID,uWorkGroupID,uRemark,uCreatorID,uCreateTime,uUpdateID,uUpdateTime")] sysUserInfo sysUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.sysUserInfo.Add(sysUserInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.uCompanyID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uCompanyID);
            ViewBag.uDepID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uDepID);
            ViewBag.uWorkGroupID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uWorkGroupID);
            return View(sysUserInfo);
        }

        // GET: sysUserInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysUserInfo sysUserInfo = db.sysUserInfo.Find(id);
            if (sysUserInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.uCompanyID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uCompanyID);
            ViewBag.uDepID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uDepID);
            ViewBag.uWorkGroupID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uWorkGroupID);
            return View(sysUserInfo);
        }

        // POST: sysUserInfoes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "uID,uLoginName,uLoginPWD,uRealName,uTelphone,uMobile,uEmial,uQQ,uGender,uStatus,uCompanyID,uDepID,uWorkGroupID,uRemark,uCreatorID,uCreateTime,uUpdateID,uUpdateTime")] sysUserInfo sysUserInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysUserInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.uCompanyID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uCompanyID);
            ViewBag.uDepID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uDepID);
            ViewBag.uWorkGroupID = new SelectList(db.sysOrganStruct, "osID", "osName", sysUserInfo.uWorkGroupID);
            return View(sysUserInfo);
        }

        // GET: sysUserInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysUserInfo sysUserInfo = db.sysUserInfo.Find(id);
            if (sysUserInfo == null)
            {
                return HttpNotFound();
            }
            return View(sysUserInfo);
        }

        // POST: sysUserInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sysUserInfo sysUserInfo = db.sysUserInfo.Find(id);
            db.sysUserInfo.Remove(sysUserInfo);
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

        public ActionResult GetJson() {
            return Json(new { status = 0, msg = "" }, JsonRequestBehavior.AllowGet);
        }
    }
}
