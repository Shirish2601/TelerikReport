using Microsoft.Extensions.DependencyInjection.Extensions;
using ProductInformation.API.Repository;
using Telerik.Reporting.Cache.File;
using Telerik.Reporting.Services;

namespace ProductInformation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureServices(builder.Services);
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();
            app.UseCors("AllowOrigin");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.Run();
        }

        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddTransient<ProductRepository>();
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddControllers()
                .AddNewtonsoftJson();

            services.TryAddSingleton<IReportServiceConfiguration>(sp =>
                new ReportServiceConfiguration
                {
                    ReportingEngineConfiguration = sp.GetService<IConfiguration>(),
                    Storage = new FileStorage(),
                    ReportSourceResolver = new TypeReportSourceResolver()
                            .AddFallbackResolver(new UriReportSourceResolver(
                                System.IO.Path.Combine(sp.GetService<IWebHostEnvironment>()!.WebRootPath, "Reports"))),
                });
        }
    }
}
