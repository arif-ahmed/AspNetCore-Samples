using System;
using ErrorHandling.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    public class HomeController : Controller
    {
        [HandleException]
        //[HandleException(ViewName = "Error",
        //ExceptionType = typeof(DivideByZeroException))]
        //[HandleException(ViewName = "Error")]
        public IActionResult Index()
        {
            throw new Exception("This is some exception!!!");
            //return View();
        }
    }
}