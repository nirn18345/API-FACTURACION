using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace APIPrueba
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            //este es un comentario nuevoo  sasafasfas

            //nuevo cambio ssss
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });
    }
}