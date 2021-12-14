using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace EASV.CS20B.FW.WorkScheduleProject.WebApi
{
    public class Program
    {
        //Running the program
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        //this method creates and configures the Startup class
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
