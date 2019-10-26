using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClockHackInsight.Backend;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ClockHackaInsight.Backend
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
          //  return Host.CreateDefaultBuilder(args)
          //.ConfigureServices((hostContext, services) =>
          //{
          //     // services.AddHostedService<Worker>();
          //});
        }
    }
}
