using BussinesLogic.Interface;
using BussinesLogic.Interface.ListInterface;
using BussinesLogic.Service;
using Entities.Entity;
using Microsoft.Extensions.DependencyInjection;
using Repository.Interface;
using Repository.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Infrastructure.Interface
{
    public static class Infrastructure
    {
        public static void LoadConfiguration(IServiceCollection services)
        {
            services.AddScoped<IConsultationList,ConsultationService>();

            services.AddScoped<IBaseService<Country>, CountryService>();
            services.AddScoped<IRepository<Country>, CountryRepository>();
            //
            services.AddScoped<IBaseService<MedicalFile>, MedicalFileService>();
            services.AddScoped<IRepository<MedicalFile>, MedicalFileRepository>();
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
            services.AddScoped<IRepository<AnalysisDoctor>, AnalysisDoctorRepository>();
            services.AddScoped<IBaseService<AnalysisDoctor>, AnalysisDoctorService>();
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

        }
    }
