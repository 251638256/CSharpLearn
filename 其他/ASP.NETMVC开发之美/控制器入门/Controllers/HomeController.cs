using DynamicQuery;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using 控制器入门.Models;

namespace 控制器入门.Controllers {
    public class HomeController : Controller {

        public static Stopwatch sw = new Stopwatch();

        [AsyncTimeout(5000)]
        public async Task<ActionResult> Index(QueryDescriptor desc,string fucking,decimal money,int intvalue) {
            sw.Start();
            Model db = new Model();
            var r = db.个人信息.ToList();

            Task<int> v1 = Task.Run<int>(() => {
                Thread.Sleep(2000);//模拟特别耗时的任务
                return 1993;
            });

            Task<int> v2 = Task.Run<int>(() => {
                Thread.Sleep(2000);//模拟特别耗时的任务
                return 1994;
            });

            Task<int> v3 = Task.Run<int>(() => {
                Thread.Sleep(2000);//模拟特别耗时的任务
                return 1995;
            });

            await Task.WhenAll(v1, v2, v3);
            sw.Stop();
            double sec = sw.ElapsedMilliseconds / 1000.0;
            ViewData["sec"] = sec;
            ViewData["v1"] = v1.Result;
            ViewData["v2"] = v2.Result;
            ViewData["v3"] = v3.Result;

            return View();
        }

        public ActionResult About() {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(IEnumerable<基本信息> 基本信息集) {
            ViewBag.Message = "Your contact page.";

            return View();
        }


    }
}