using ATM.DAL;
using ATM.DAL.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using ATM.Admin.Utils;
using ATM.DAL.Services;
using ATM.Admin.Controllers;
using ATM.RequestLog.Data;
using ATM.RequestLog.Middleware;
using ATM.RequestLog.Services;

namespace ATM.Admin
{
    /// <summary>
    /// Startup
    /// </summary>
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
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddDbContext<LogDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("LogDatabaseConnection")));
            services.AddTransient<LogService>();
            services.AddTransient<BaseService>();
            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
            options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });

            services.AddTransient(m => new UserManager(Configuration.GetValue<string>("")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext appDbContext, LogDbContext logDbContext)
        {
            try
            {
                // appDbContext.Database.EnsureDeleted();
                appDbContext.Database.EnsureCreated();
                DataSeeder.Initialize(appDbContext);

                logDbContext.Database.EnsureCreated();
            }
            catch (Exception ex)
            {
                var e = ex;
                Console.WriteLine("An error occurred while seeding the database.");
            }


            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
            }
            else
            {
                // app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                ///app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<LogMiddleware>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "account",
                    pattern: "{controller=Account}/{action=Index}/{id?}");
            });
        }
    }

}
