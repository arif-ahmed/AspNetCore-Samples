using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class CustomHeaderMiddleware
    {
        private RequestDelegate _next;

        public CustomHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //In this middleware, we will always return 
            // a response header called "Custom-Middleware-Value"
            await _next.Invoke(context);
            context.Response.Headers.Add("Custom-Middleware-Value", DateTime.Now.ToString());
        }
    }
}
