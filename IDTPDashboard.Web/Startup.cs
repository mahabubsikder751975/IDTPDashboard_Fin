using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IDTPDashboard.DataAccess.Interface;
using IDTPDashboard.DataAccess.Repository;
using IDTPDashboard.DataAccess.Repositoty;
using IDTPDashboard.DomainModel.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace IDTPDashboard.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllersWithViews();
            services.AddScoped<IUserRepository, UserRepository>();
           // services.AddScoped<IParticularsRepository, ParticularsRepository>();
            services.AddScoped<IMenu_Repository, Menu_Repository>();
           // services.AddScoped<IGraphRepository, GraphRepository>();

            //charts
            services.AddScoped<IIDTPDashboard_Repository, IDTPDashboard_Repository>();
            //services.AddScoped<IHRManagement_Part2_Repository, HRManagement_Part2_Repository>();
           // services.AddScoped<IHRFinance_Repository, HRFinance_Repository>();
           // services.AddScoped<IFAManagement_Repository, FAManagement_Repository>();
           // services.AddScoped<IFAFinance_Repository, FAFinance_Repository>();
          //  services.AddScoped<IPR_Repository, PR_Repository>();
            // services.AddScoped<IFinance_Repository, Finance_Repository>(); 
            // services.AddScoped<IHRExecutive_Repository, HRExecutive_Repository>();
            // services.AddScoped<IFinence_Executive_Repository, Finence_Executive_Repository>();
            // services.AddScoped<IOfficeRepository, OfficeRepository>();
            // services.AddScoped<ILanding_Repository, Landing_Repository>();



            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, config => {
                    config.Cookie.Name = "Dashboard.Cookie";
                    //config.LoginPath = "/Account/Login";
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            var path = Directory.GetCurrentDirectory();
            loggerFactory.AddFile($"{path}\\Logs\\Log.txt");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            

            app.UseRouting();
            //who are you?
            app.UseAuthentication();
            //are you allowed?
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Dashboard}/{action=Index}/{id?}");
            });
        }
    }
}
