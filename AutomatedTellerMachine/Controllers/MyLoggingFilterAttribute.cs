using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    public class MyLoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var request = filterContext.HttpContext.Request;
            Debug.WriteLine("UserHostName:" + request.UserHostName +
                            ", " +
                            "UserHostAddress" +
                            request.UserHostAddress);
            base.OnActionExecuted(filterContext);
        }
    }
}