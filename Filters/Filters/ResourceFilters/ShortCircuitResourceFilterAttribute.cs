using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Filters.Filters.ResourceFilters
{
    public class ShortCircuitResourceFilterAttribute
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            //As context.Result is of type IActionResult
            //So you can think what we can pass with it.
            context.Result = new ContentResult()
            {
                //We can set ContentType, StatusCode & Content
                //Set as per your need                
                Content = "Resource unavailable - header should not be set"
            };
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
        }
    }
}
