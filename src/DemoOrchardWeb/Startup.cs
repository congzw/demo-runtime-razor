using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DemoOrchardWeb
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IMvcBuilder>(o =>
            {
                o.AddRazorRuntimeCompilation();
            });

            services.AddOrchardCore(orchard =>
            {
                //orchard.AddBackgroundService();
                orchard.AddMvc();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseOrchardCore();
        }
    }
}
