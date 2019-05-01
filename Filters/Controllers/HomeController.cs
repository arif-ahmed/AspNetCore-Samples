using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Filters.Filters.ActionFilters;
using Microsoft.AspNetCore.Mvc;

namespace Filters.Controllers
{

    public class HomeController : Controller
    {
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