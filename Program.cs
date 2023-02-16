using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace APIPrueba
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
<<<<<<< HEAD
=======

            
>>>>>>> 947f4b923517d49cbc833f0d5d3fe1a562adb10f
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
    }
}