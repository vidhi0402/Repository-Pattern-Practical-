using Domain.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Repositories.Repository;
using Repositories.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using ServiceStack.FluentValidation.Attributes;
using FluentValidation.AspNetCore;
using System.Reflection;
using Domain.ValidateEntity;
using Repositories.IRepository;

namespace WebAPI_Crud
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
            services.AddDbContext<CrudDBContext>(
    options =>
        options.UseSqlServer(
            Configuration.GetConnectionString("Default"),
            x => x.MigrationsAssembly("Migration")));
           
            services.AddControllersWithViews();
            services.AddAutoMapper(typeof(Startup));
            services.AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssemblyContaining<Startup>();
               
            });
            services.AddTransient<IValidator<Country>, CountryValidator>();
            services.AddTransient<IValidator<State>, StateValidator>();
            services.AddTransient<IValidator<Customer>, CustomerValidator>();

            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
