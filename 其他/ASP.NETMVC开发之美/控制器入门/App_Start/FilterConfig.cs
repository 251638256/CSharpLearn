﻿using System.Web;
using System.Web.Mvc;

namespace 控制器入门 {
    public class FilterConfig {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
