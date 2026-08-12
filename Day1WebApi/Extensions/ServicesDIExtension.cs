using Day1WebApi.Interfaces;
using Day1WebApi.Services;
using System.Reflection;

namespace Day1WebApi.Extensions
{
    public static class ServicesDIExtension
    {
        public static IServiceCollection RegisterDIService(this IServiceCollection services)
        {
            services.AddScoped<KategoriService>();
            services.AddScoped<IAsetService, AsetService>();
            services.AddScoped<PegawaiService>();
            return services;
        }

        public static void RegisterRepository(this IServiceCollection services)
        {

        }

        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
           return services.AddSwaggerGen(config =>
            {
                var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
                var xmlFile = $"{assemblyName}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                {
                    config.IncludeXmlComments(xmlPath);
                }

            });

            
        }

        public static void AddDevAppDependency(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();
        }
    }
}
