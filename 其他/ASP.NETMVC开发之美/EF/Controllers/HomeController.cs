using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF.Controllers
{
    public class HomeController : Controller
    {
        MyDbContext context = new MyDbContext();

        // GET: Home
        public ActionResult Index()
        {
            var data = context.Blog.ToArray();
            context.SaveChanges();
            return View();
        }
    }
}