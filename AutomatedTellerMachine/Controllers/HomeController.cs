using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutomatedTellerMachine.Controllers
{
    // [Authorize]: The AuthorizeAttribute can also be added to the class level, which makes all the actions in this class with that AuthorizeAttribute.
    // If you want a specific action to have a different AuthorizeAttribute, just put that AuthorizeAttribute before the desired action. This attribute 
    // can override the AuthorizeAttribute specified in the class level.
    public class HomeController : Controller
    {
        // GET /
        // GET /home
        // GET /home/index
        public ActionResult Index()
        {
            return View();
            //return PartialView(); Render a section of a web page. This will lose the layout information.
        }

        // Get /home/about-the-atm
        // The ActionName represents the name of the action. For example, the "-" symbol is not allowed in 
        // the action method name. If we want to use the "-" character in the URL, we must use the ActionNameAttribute.
        [ActionName("about-the-atm")]
        public ActionResult About()
        {
            // The ViewBag is used to pass information between action method and the view.
            // This information is available only if the action method returns the View,
            // if the action method redirects to another action method, that information is not available.
            ViewBag.Message = "Your application description page.";

            // By default, the View() will return the View that has the same name with the action, or the View 
            // that has the same name with the ActionNameAttribute(if specified).
            return View("About");
        }

        // [AllowAnonymous]: allows any visitors.
        // [Authorize]: allows any logged-in users.
        // [Authorize(Roles="administrator", Users="jsmith")]: allows the user of 'jsmith', or users with administrator role.
        [MyLoggingFilter]   // Action filter
        /*
         * An action filter consists of logic that runs directly before or directly after an action method runs.
         * You can use action filters for logging, authentication, output caching, or other tasks.
         * You implement an action filter as an attribute that inherits from the ActionFilterAttribute class.
         * You override the OnActionExecuting method if you want your logic to run before the action method.
         * You override the OnActionExecuted method if you want your logic to run after the action method.
         * You can also apply the action filter globally. This can be done by adding a new action filter instance
         * to GlobalFilterCollection in the FilterConfig.cs file.
         */
        public ActionResult Contact()
        {
            ViewBag.Message = "Having a problem? Send us a message.";

            return View();
        }

        // The name of the parameter 'message' must match the name of the form element name (here is the textarea name).
        [HttpPost]  // 'This attribute restricts the action method to handle only Http POST request.
        public ActionResult Contact(string message)
        {
            ViewBag.Message = "Thanks. We have got your message: " + message;

            return View();
        }

        public ActionResult Serial(string letterCase)
        {
            const string serialNumber = "ATMSERIALNUMBER";

            ContentResult cr = letterCase.ToLower().Equals("lower") ? Content(serialNumber.ToLower()) : Content(serialNumber);

            return cr;

            // This will return a JsonResult.
            // return Json(new { name = "serial", value = serialNumber }, JsonRequestBehavior.AllowGet);

            // This will redirect to the 'Index' action.
            // return RedirectToAction("Index");
        }
    }
}