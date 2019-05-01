using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Text.RegularExpressions;

namespace Filters.Filters.ResourceFilters
{
    public class IEFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }

        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            string userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
            if (Regex.IsMatch(userAgent, "MSIE [6-9]") || userAgent.Contains("Trident"))
            {
                context.Result = new ContentResult { Content = "Your browser is not supported" };
            }
        }
    }
}
