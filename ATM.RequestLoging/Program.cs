using System;
using ATM.RequestLog.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ATM.RequestLog
{
    /// <summary>
    /// Program
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<LogDbContext>();
                    context.Database.EnsureCreated();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred while seeding the database.");
                    Console.WriteLine(ex.Message);
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args);
    }
}
