﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BussinesLogic.Interface;
using BussinesLogic.Service;
using Entities;
using Entities.Entity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Repository.Interface;
using Repository.Repo;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace ApiMedical
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

        services.AddOData();
            services.AddODataQueryFilter();
          
        services.AddMvc(options=>{
             options.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var connectionString = Configuration["sqlconnection:connectionString"];
            services.AddDbContext<MedicalContext>(options =>
                  options.UseSqlServer(connectionString));
            var mapper = Maping.Mapping.GetMapper();
            services.AddSingleton(mapper);
            services.AddScoped<IBaseService<Country>, CountryService>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<ILanguage, LanguageRepository>();



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
      
            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Filter().OrderBy().Expand().Count().MaxTop(10);

            });
        }
     
    }
}