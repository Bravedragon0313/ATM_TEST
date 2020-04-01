using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using ATM.Server.Hubs;
using ATM.DAL.Data;
using Microsoft.EntityFrameworkCore;

namespace ATM.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IMyFileWatcher _watcher;
        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IMyFileWatcher, MyFileWatcher>();
            services.AddScoped<DAL.Services.BaseService, DAL.Services.BaseService>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(Configuration.GetConnectionString("DatabaseConnection")));
            services.AddSignalR();
            services.AddMvc();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMyFileWatcher watcher)
        {
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                //app.UseAuthentication();
            }
            _watcher = watcher;

            app.UseFileServer();

            app.UseSignalR(routes =>
            {
                routes.MapHub<FileWatcherHub>("/fileWatcherHub");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
