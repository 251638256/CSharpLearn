using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 控制器入门.Models;

namespace 控制器入门.Controllers
{
    public class DefaultController : Controller
    {
        Model db = new Model();
        // GET: Default
        public ActionResult Index()
        {

            return View(new List<受检者个人信息>());
        }

        // GET: Default/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Default/Create
        public ActionResult Create()
        {
            return PartialView();
            //return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(受检者个人信息 个人)
        {
            try
            {
                // TODO: Add insert logic here
                if (Request.IsAjaxRequest()) {
                    Console.WriteLine();
                }
                db.个人信息.Add(个人);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return PartialView();
            }
        }

        // GET: Default/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Default/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {

                throw new Exception("Exception");

            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }

        // GET: Default/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
