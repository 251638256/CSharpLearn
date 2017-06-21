#define MYDEBUG

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bootstrap.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache]
        public ActionResult Index()
        {


            return View();
        }
        
        public ActionResult About() {
            Debug.Write("Debug");
            Trace.Write("Debug");
            return View();
        }

        [Conditional("Debug")]
        public void Test() {

        }
    }
}