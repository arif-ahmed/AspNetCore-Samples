using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Filters.Filters.ResultFilters
{
    public class TimeExecutionFilterAttribute : Attribute, IResultFilter
    {
        DateTime start;
        public void OnResultExecuting(ResultExecutingContext context)
        {
            start = DateTime.Now;
        }
        public async void OnResultExecuted(ResultExecutedContext context)
        {
            DateTime end = DateTime.Now;
            double processTime = end.Subtract(start).TotalMilliseconds;
            await context.HttpContext.Response.WriteAsync($"Time to complete the result: {processTime} milliseconds");
        }
    }
}
