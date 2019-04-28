using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ErrorHandling.Controllers
{
    public class StatusCodeController : Controller
    {
        [Route("statuscode/{code:int}")]
        public IActionResult Index(int code)
        {
            return View();
        }
    }
}