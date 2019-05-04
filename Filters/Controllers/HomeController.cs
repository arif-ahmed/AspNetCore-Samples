using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Filters.ActionFilters;
using Filters.Filters.AuthorizationFilters;
using Filters.Filters.ExceptionFilters;
using Filters.Filters.ResultFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{
    [CustomAuthorization]
    [ServiceFilter(typeof(DemoExceptionFilter))]
    [ServiceFilter(typeof(LoggingActionFilter))]
    public class HomeController : Controller
    {
        [TimeExecutionFilter]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AboutUs()
        {
            return Content("About Us Page");
            //return View();
        }
    }
}