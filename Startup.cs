using APIPrueba.Datos;
using APIPrueba.Utils;
using GDifare.Utilitario.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIPrueba
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
            // Configuración de Swagger
            services.AddSwaggerConfigureServices(StringHandler.ModuleName, StringHandler.ProjectName, 1);

            // Servicios MVC
            services.AddControllers();

            // HealthChecks
            services.AddHealthChecks();

            // Configuración del servicio
            services.AddScopedServices();

            // Configuración de implementaciones de interfaces
            services.AddTransient<IMapeoDatosSumarioVentas, MapeoDatosSumarioVentas>();
            services.AddTransient<IMapeoDatosCliente, MapeoDatosCliente>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            // Configuración de Swagger
            app.AddSwaggerConfigureApplicationBuilder(StringHandler.ModuleName, StringHandler.ProjectName, 1);

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health");
                endpoints.MapHealthChecks("/health/liveness");
                endpoints.MapHealthChecks("/health/readiness");
            });
        }
    }
}