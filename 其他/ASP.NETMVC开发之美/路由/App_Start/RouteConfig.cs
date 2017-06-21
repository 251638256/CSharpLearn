using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace 路由 {
    public class RouteConfig {
        public static void RegisterRoutes(RouteCollection routes) {
            //routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.IgnoreRoute("{resource}.js/{*pathInfo}");

            /*
             UrlParameter.Optional 可选的参数 不能是controller 和 test
             controller 和 action 是内置的两个参数表示控制器和方法名字
             id是属于自定义的参数,并且设置该参数为UrlParameter.Optional表示可以只写id是可选的
             路由路径可以加入硬编码内容url: "{action}/my{test}/{id}", 
             硬编码内容是必须输入的,如果直接使用/action是找不到的内容的 必须是/action/my + 任意test占位符

            controller和action必须有一个 并且 设置了默认的另一个 如果只有controller必须设置默认action 如果只有action必须设置默认的controller

             */

            //routes.MapMvcAttributeRoutes();

            //routes.MapRoute(
            //    name: "Test",
            //    url: "{action}/{test}/{id}",
            //    defaults: new { controller = "Home", test = UrlParameter.Optional, id = UrlParameter.Optional },
            //    constraints: new { test = new MyRouteEqEmpty() },
            //    namespaces : new[] { "路由.Controllers" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new[] { "路由.Controllers" }
            );
        }
    }

    /// <summary>
    /// 自定义过滤规则(test必须大于10的数字)
    /// </summary>
    public class MyRoute : IRouteConstraint {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
            if (values.ContainsKey(parameterName)) {
                string v = values[parameterName].ToString();
                int outValue;
                if (int.TryParse(v, out outValue)) {
                    if (outValue > 10) {
                        return true;
                    }
                }
            }
            return false;
        }
    }

    /// <summary>
    /// 自定义规则 
    /// </summary>
    public class MyRouteEqEmpty : IRouteConstraint {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection) {
            if (values.ContainsKey(parameterName)) {
                string v = values[parameterName].ToString();
                if (string.IsNullOrWhiteSpace(v)) return true;
                int outValue;
                if (int.TryParse(v, out outValue)) {
                    if (outValue > 10) {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
