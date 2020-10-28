using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LandscapeInstitute.WebAPI.Client;

namespace LandscapeInstitute.WebAPI.Client.Example
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
     

            services.AddLandscapeService(options =>
            {
                options.BaseUrl = "https://dev-api.landscapeinstitute.org";
    
            });

            /* Add Instance Landscape Service */
            services.AddLandscapeService(options =>
            {
                options.BaseUrl = "https://dev-api.landscapeinstitute.org";
                options.Authentication = new ClientAuthentication()
                {
                    Token = "12345",
                    Type = ClientAuthenticationType.ApiKey
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
