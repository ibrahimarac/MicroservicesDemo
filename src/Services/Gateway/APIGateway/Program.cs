using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ocelot.DependencyInjection;

namespace APIGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host,config)=>
            {
                config
                    .SetBasePath(host.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile("ocelot.json");
                    
                //config
                //    .SetBasePath(host.HostingEnvironment.ContentRootPath)
                //    .AddJsonFile("appsettings.json", true, true)
                //    .AddJsonFile($"ocelot.{host.HostingEnvironment.EnvironmentName}.json", true, true)
                //    .AddOcelot("OcelotConfiguration",)
                //    .AddEnvironmentVariables();

                //config.AddOcelotWithSwaggerSupport(options =>
                //{
                //    options.Folder = "OcelotConfiguration";
                //});
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {                    
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}
