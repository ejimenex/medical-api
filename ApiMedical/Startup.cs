using Repository.Dtos;
using BussinesLogic.Interface;
using BussinesLogic.Service;
using Entities;
using Entities.Entity;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OpenApi.Models;
using Repository.Interface;
using Repository.Repo;
using System.Linq;

namespace ApiMedical
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

            
            services.AddODataQueryFilter();

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            //services.AddOData();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Medical", Version = "v1" });
            });
            //services.Configure<MvcOptions>(options =>
            //{
            //    options.Filters.Add(new CorsAuthorizationFilterFactory("EveryOne"));
            //});
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            var connectionString = Configuration["sqlconnection:connectionString"];
            services.AddDbContext<MedicalContext>(options =>

                  options.UseSqlServer(connectionString).UseLazyLoadingProxies());

            var mapper = Maping.Mapping.GetMapper();
            services.AddSingleton(mapper);
           Infrastructure.Interface.Infrastructure.LoadConfiguration(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });
            //app.UseRouting();
            //app.UseEndpoint(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseMvc(routeBuilder =>
            {
                //routeBuilder.EnableDependencyInjection();
                
                //routeBuilder.Select().Filter().OrderBy().Expand().Count().MaxTop(10);
                //routeBuilder.MapODataServiceRoute("odata", "api", GetEdmModel());
            });
        }
        IEdmModel GetEdmModel()
        {
            var odataBuilder = new ODataConventionModelBuilder();
            odataBuilder.EntitySet<Currency>("Currency");
            odataBuilder.EntitySet<HealthManagerDto>("ArsList");
            odataBuilder.EntitySet<PatientDto>("Patient");
            odataBuilder.EntitySet<DoctorDto>("Doctor");
            odataBuilder.EntitySet<MedicalCenterDto>("MedicalCenter");
            odataBuilder.EntitySet<DocumentType>("DocumentType");
            odataBuilder.EntitySet<CountryDto>("CountryList");
            odataBuilder.EntitySet<UserDto>("User");
            odataBuilder.EntitySet<MedicalScheduleDto>("MedicalSchedule");
            odataBuilder.EntitySet<DoctorOfficeDto>("DoctorOffice");
            odataBuilder.EntitySet<ConsultationDto>("Consultation");
            odataBuilder.EntitySet<MedicalFormDto>("MedicalForm");
            odataBuilder.EntitySet<AppointmentDto>("AppointmentList");

            odataBuilder.EntitySet<MedicalServiceDto>("MedicalService");
            odataBuilder.EnableLowerCamelCase();
            return odataBuilder.GetEdmModel();
        }

    }
}
