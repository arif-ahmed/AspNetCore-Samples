using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middleware.Middlewares
{
    public class AuthorizedPostMiddleware
    {
        //The RequestDelegate represents the next middleware in the pipeline.
        private RequestDelegate _next;

        //Said delegate must be passed in from the previous middleware.
        public AuthorizedPostMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        //The Invoke method is called by the previous middleware 
        //to kick off the current one.
        public Task Invoke(HttpContext context)
        {
            //In this middleware, if the user is not authenticated 
            //and the request is a POST, we return 401 Unauthorized
            if (!context.User.Identity.IsAuthenticated && context.Request.Method == "POST")
            {
                context.Response.StatusCode = 401;
                return context.Response.WriteAsync("You are not permitted to perform POST actions.");
            }

            //Finally, we call Invoke() on the next middleware in the pipeline.
            return _next.Invoke(context);
        }
    }
}
