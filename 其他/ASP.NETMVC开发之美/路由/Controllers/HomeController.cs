using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace 路由.Controllers {

    [RoutePrefix("MyHome")]
    public class HomeController : Controller {

        [Route("MyIndex/{id?}")]
        public ActionResult Index(string test, string id) {

            var r  = RouteTable.Routes.GetVirtualPathForArea(Request.RequestContext, new RouteValueDictionary(new { test = 1 }))
                .VirtualPath;
            
            return View();
        }

        public ActionResult About(string test, string id,string controller) {
            ViewBag.Message = $"test = {test}, id = {id}, controller = {controller}";

            return View();
        }

        public ActionResult Contact() {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Element() {
            throw new NotImplementedException("Not Implmented");

            string v = Request.Headers["Authcation"].ToString();
            if (string.IsNullOrWhiteSpace(v)) {

            } else {

            }
            return View();
        }

        protected override void OnException(ExceptionContext filterContext) {

            filterContext.ExceptionHandled = true;
            //base.OnException(filterContext);
        }



    }
}