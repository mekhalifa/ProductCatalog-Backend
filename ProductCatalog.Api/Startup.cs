using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using ProductCatalog.Application.Interfaces.IRepos;
using ProductCatalog.Application.Interfaces.IUnitOfWorks;
using ProductCatalog.Infrastructure.Repos;
using ProductCatalog.Infrastructure.UnitOfWork;
using ProductCatalog.Persistence;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalog.Api
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
            services.AddDbContext<ProductCatalogContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ProductCatalogDb"))
                                                                   .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddControllers();
            
            services.AddScoped(typeof(IGenericRepo<>),typeof( GenericRepo<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddCors();

            services.AddSwaggerGen( opt =>{
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = " Product Catalog API",
                    Version = "v1",
                    Description = "Product Catalog API Swagger",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohamed Khalifa",
                        Email = string.Empty,
                        Url = new Uri(@"https://github.com/mekhalifa"),
                    },
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(opt=> {

                opt.SwaggerEndpoint("/swagger/v1/swagger.json", "Product Catalog API V1");

                opt.RoutePrefix = string.Empty;
               
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
