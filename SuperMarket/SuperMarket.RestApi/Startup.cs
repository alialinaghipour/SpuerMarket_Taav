using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SupeMarket.Persistence.EF;
using SupeMarket.Persistence.EF.ProductCategories;
using SupeMarket.Persistence.EF.ProductEntries;
using SupeMarket.Persistence.EF.Products;
using SupeMarket.Persistence.EF.SalesFactories;
using SuperMarket.Infrastructure.Application;
using SuperMarket.Services.ProductCategories;
using SuperMarket.Services.ProductCategories.Contracts;
using SuperMarket.Services.ProductEntries;
using SuperMarket.Services.ProductEntries.Contracts;
using SuperMarket.Services.Products;
using SuperMarket.Services.Products.Contracts;
using SuperMarket.Services.SalesFactories;

namespace SuperMarket.RestApi
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
            services.AddControllers();

            services.AddDbContext<EFDataContext>(options =>
            {
                options.UseSqlServer("Server =.; Database = SuperMarket_Taav; Trusted_Connection = True; ");
            });

            services.AddScoped<ProductCategoryServices, ProductCategoryAppServices>();

            services.AddScoped<ProductCagetoryRepository, EFProductCategoryRepository>();

            services.AddScoped<ProductEntryServices, ProductEntryAppServices>();

            services.AddScoped<ProductEntryRepository, EFProductEntryRepository>();

            services.AddScoped<ProductServices, ProductAppServices>();

            services.AddScoped<ProductRepository, EFProductRepository>();

            services.AddScoped<SalesFactoryServices, SalesFactoryAppServices>();

            services.AddScoped<SalesFactoryRepository, EFSalesFactoryRepository>();

            services.AddScoped<UnitOfWork, EFUnitOfWork>();



            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
