using System;
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
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using ApiMedical.Dtos;

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

           
            services.AddOData();
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
            services.AddScoped<IBaseService<Country>, CountryService>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            //
            services.AddScoped<IBaseService<Users>, UserService>();
            services.AddScoped<IRepository<Users>, UserRepository>();
            //
            services.AddScoped<IBaseService<HealthManager>, HealthManagerService>();
            services.AddScoped<IRepository<HealthManager>, HealthManagerRepository>();
            //
            services.AddScoped<ILanguage, LanguageRepository>();
            services.AddScoped<IGetData<Parameter>, ParameterRepository>();
            services.AddScoped<IGetData<DocumentType>, DocumentTypeRepository>();
            //
            services.AddScoped<IRole, RoleRepository>();
            services.AddScoped<IPermission, PermisionRepository>();
            services.AddScoped<IMedicalCenterDoctor, MedicalCenterDoctorRepository>();
            services.AddScoped<IReasonRepository, ReasonConsultationRepository>();
            services.AddScoped<IMenu, MenuRepository>();
            services.AddScoped<ICurrency, CurrencyRepository>();
            services.AddScoped<IDiscountReason, DiscountReasonRepository>();
            services.AddScoped<IInvoideDetail, InvoiceDetailRepository>();
            //
            services.AddScoped<IAccount, AccountService>();
            //
            services.AddScoped<IRepository<Invoice>, InvoiceRepository>();
            services.AddScoped<IBaseService<Invoice>, InvoiceService>();
            
            //

            services.AddScoped<IRepository<PatientForm>, PatientFormRepository>();
            services.AddScoped<IBaseService<PatientForm>, PatientFormService>();
            //
            services.AddScoped<IRepository<Documents>, DocumentRepository>();
            services.AddScoped<IBaseService<Documents>, DocumentService>();
            //
            services.AddScoped<IBaseService<Prescription>, PrescriptionService>();
            services.AddScoped<IRepository<Prescription>, PrescriptionRepository>();
            //
            services.AddScoped<IBaseService<Appointment>, AppointmentService>();
            services.AddScoped<IRepository<Appointment>, AppointmentRepository>();
            //
            services.AddScoped<IBaseService<EventTypes>, EventTypeService>();
            services.AddScoped<IRepository<EventTypes>, EventTypeRepository>();
            //
            services.AddScoped<IBaseService<MedicalCenter>, MedicalCenterService>();
            services.AddScoped<IRepository<MedicalCenter>, MedicalCenterRepository>();
            //
            services.AddScoped<IBaseService<MedicalForm>, MedicalFormService>();
            services.AddScoped<IRepository<MedicalForm>, MedicalFormRepository>();
            //
            services.AddScoped<IBaseService<MedicalSpeciality>, MedicalSpecialityService>();
            services.AddScoped<IRepository<MedicalSpeciality>, MedicalSpecialityRepository>();
            //
            services.AddScoped<IBaseService<Patient>, PatientService>();
            services.AddScoped<IRepository<Patient>, PatientRepository>();
            //
            services.AddScoped<IBaseService<MedicalSchedule>, MedicalScheduleService>();
            services.AddScoped<IRepository<MedicalSchedule>, MedicalScheduleRepository>();
            //
            services.AddScoped<IBaseService<Doctor>, DoctorService>();
            services.AddScoped<IRepository<Doctor>, DoctorRepository>();
            //
            services.AddScoped<IBaseService<Consultation>, ConsultationService>();
            services.AddScoped<IRepository<Consultation>, ConsultationRepository>();
            //
            services.AddScoped<IBaseService<PersonalSchedule>, PersonalScheduleService>();
            services.AddScoped<IRepository<PersonalSchedule>, PersonalScheduleRepository>();
            //
            services.AddScoped<IBaseService<MedicalServices>, MedicalServicesService>();
            services.AddScoped<IRepository<MedicalServices>, MedicalServicesRepository>();
            //
            services.AddScoped<IBaseService<DoctorOffice>, DoctorOfficeService>();
            services.AddScoped<IRepository<DoctorOffice>, DoctorOfficeRepository>();
            //
            services.AddScoped<IRepository<MedicalSpecialityDoctor>, MedicalSpecialityDoctorRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                
                routeBuilder.Select().Filter().OrderBy().Expand().Count().MaxTop(10);
                routeBuilder.MapODataServiceRoute("odata", "api", GetEdmModel());
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
