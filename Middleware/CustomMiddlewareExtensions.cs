using Microsoft.AspNetCore.Builder;
using Middleware.Middlewares;


namespace Middleware
{
    public static class CustomMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuthorizedPost(this IApplicationBuilder app)
        {
            return app.UseMiddleware<AuthorizedPostMiddleware>();
        }

        public static IApplicationBuilder UseCustom(this IApplicationBuilder builder)
        {

            return builder.UseMiddleware<CustomMiddleware>();
        }
    }
}
