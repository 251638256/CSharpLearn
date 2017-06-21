using DynamicQuery;
using DynamicQuery.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using 控制器入门.Model_Bind;

namespace 控制器入门 {
    public class MvcApplication : System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ModelBinders.Binders.Add(typeof(object), new BasicBinder());
            ModelBinders.Binders.Add(typeof(QueryDescriptor), new QueryDescriptorBinder());
            ModelBinders.Binders.Add(typeof(decimal), new BasicBinder());
            ModelBinders.Binders.Add(typeof(int), new IntBinder());
        }
    }

    class IntBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var value = controllerContext.Controller.ValueProvider.GetValue(bindingContext.ModelName);
            return 10086;
        }
    }
}
