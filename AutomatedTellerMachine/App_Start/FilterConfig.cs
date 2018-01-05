using System.Web;
using System.Web.Mvc;
using AutomatedTellerMachine.Controllers;

namespace AutomatedTellerMachine
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            // Apply the action filter globally.
            // It applies related action filter to all the actions in the application.
            filters.Add(new HandleErrorAttribute());
            filters.Add(new MyLoggingFilterAttribute());
        }
    }
}
