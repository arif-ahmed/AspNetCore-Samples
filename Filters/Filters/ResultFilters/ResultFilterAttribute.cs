using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filters.Filters.ResultFilters
{
    public class ResultFilterAttribute : Attribute, IAsyncResultFilter
    {
        public async Task OnResultExecutionAsync(ResultExecutingContext context,
                                                        ResultExecutionDelegate next)
        {
            context.HttpContext.Response.Headers.Add("DateTime", DateTime.Now.ToString());
            await next();
        }
    }
}
