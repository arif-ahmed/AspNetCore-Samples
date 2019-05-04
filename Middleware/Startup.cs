using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Middleware.Middlewares;

namespace Middleware
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            //services.AddDbContext<ApplicationDbContext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //services.AddDefaultIdentity<IdentityUser>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>();


            services.AddResponseCompression();
            services.AddResponseCaching();

            // If the app uses session state, call AddSession.
            services.AddSession();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            if(env.IsStaging() || env.IsProduction())
            {
                app.UseExceptionHandler("/Home/Error");

                // will add the HSTS response header which the client is supposed to obey
                app.UseHsts();
            }

            app.UseResponseCaching();
            app.UseResponseCompression();

            // will issue HTTP response codes redirecting from http to https
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            // If you want to invoke a piece of middleware but not end the pipeline, use app.Use()
            // This method chains middleware so that you can modify the response without immediately returning it.
            app.Use(async (context, next) =>
            {
                await next.Invoke();
                context.Response.Headers.Add("AppUseRan", "yes");
            });

            // Now let's add our custom middleware!
            app.UseAuthorizedPost();
            app.UseMiddleware<CustomHeaderMiddleware>();
            app.UseCustom();

            //Finally, the MVC Routing middleware establishes the routes needed to access our MVC application.
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
