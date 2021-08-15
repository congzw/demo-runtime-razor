using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoOrchardWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //InvalidOperationException: Unable to find the required services.
            //Please add all the required services by calling 'IServiceCollection.AddControllers'
            //inside the call to 'ConfigureServices(...)' in the application startup code.
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddOrchardCore()
                //.AddBackgroundService()
                .AddMvc();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "Root",
                    pattern: "",
                    defaults: new { controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "Root_Default",
                    pattern: "/Root/{controller}/{action}",
                    defaults: new { controller = "Home", action = "Index" }
                );

                endpoints.MapControllerRoute(
                    name: "Razor",
                    pattern: "/Razor/{view}",
                    defaults: new { controller = "Razor", action = "Render" }
                );
            });

            app.UseOrchardCore();
        }
    }
}
