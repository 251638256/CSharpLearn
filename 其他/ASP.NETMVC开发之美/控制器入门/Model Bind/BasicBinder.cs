using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 控制器入门.Model_Bind {
    public class BasicBinder : IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            string name = bindingContext.ModelName;
            var value = controllerContext.Controller.ValueProvider.GetValue(name);
            ModelState state = new ModelState() { Value = value };

            decimal retValue = 0;
            try {
                retValue = decimal.Parse(value.AttemptedValue);
            } catch(Exception e) {
                state.Errors.Add(e);
            }
            bindingContext.ModelState.Add(name, state);

            return retValue;
        }
    }
}