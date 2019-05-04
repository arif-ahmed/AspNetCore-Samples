using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters.AuthorizationFilters
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class CustomAuthorization : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext filterContext)
        {
            var controllerInfo = filterContext.ActionDescriptor as ControllerActionDescriptor;
            if (filterContext != null)
            {
                string controllerName = controllerInfo.ControllerName;

                if (controllerName != "Home")
                {
                    if (filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                    {
                        filterContext.Result = new JsonResult("")
                        {
                            Value = new
                            {
                                Status = "Error"
                            },
                        };
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary {
                            {
                                "Controller","Home"
                            },
                            {
                                "Action","SessionExpired"
                            }
                        });
                    }
                }
            }
        }
    }
}
