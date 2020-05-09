using ApiMedical.Dtos;
using AutoMapper;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Maping
{
    public class Mapping
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {

            cfg.CreateMap<Country, CountryDto>().ReverseMap();
            cfg.CreateMap<Users, UserDto>().ReverseMap();
            cfg.CreateMap<Users, UserDto>()
           .ForMember(x => x.RolName, opt => opt.MapFrom(x => x.Role.RolName));
            //
            cfg.CreateMap<HealthManager, HealthManagerDto>().ReverseMap();
                cfg.CreateMap<HealthManager, HealthManagerDto>()
            .ForMember(x => x.Country, opt => opt.MapFrom(x => x.CountryOb.Name));
                //
                cfg.CreateMap<Role, RoleDto>().ReverseMap();
                //
                cfg.CreateMap<MedicalSpeciality, MedicalSpecialityDto>().ReverseMap();
                //
                cfg.CreateMap<MedicalSpecialityDoctor, MedicalSpecialityDoctorDto>().ReverseMap();
                //
                cfg.CreateMap<MedicalCenter, MedicalCenterDto>().ReverseMap();
                cfg.CreateMap<MedicalCenter, MedicalCenterDto>()
              .ForMember(x => x.CountryName, opt => opt.MapFrom(x => x.CountryObj.Name));
                //
                
                cfg.CreateMap<PatientForm, PatientFormDto>().ReverseMap();
                cfg.CreateMap<PatientForm, PatientFormDto>()
                .ForMember(x => x.Type, opt => opt.MapFrom(x => x.MedicalForm.Type))
                .ForMember(x => x.QuestionName, opt => opt.MapFrom(x => x.MedicalForm.Question));
                //
                cfg.CreateMap<Invoice, InvoiceDto>().ReverseMap();
                cfg.CreateMap<Invoice, InvoiceDto>()
                .ForMember(x => x.Discount, opt => opt.MapFrom(x => x.InvoiceDetail.Sum(c=> c.Discount)))
               .ForMember(x => x.Total, opt => opt.MapFrom(x => x.InvoiceDetail.Sum(c=> (c.Qty*c.Price)-c.Discount)))
                .ForMember(x => x.TotalItem, opt => opt.MapFrom(x => x.InvoiceDetail.Count()))
                .ForMember(x => x.OfficeName, opt => opt.MapFrom(x => x.Office.Name))
                .ForMember(x => x.PatientName, opt => opt.MapFrom(x => x.Patient.Name));
                //
                cfg.CreateMap<InvoiceDetail, InvoiceDetailDto>()
                .ForMember(c => c.MedicalService, opt => opt.MapFrom(c => c.MedicalService.Name))
                .ForMember(c => c.DiscountReason, opt => opt.MapFrom(c => c.DiscountReason.Name))
                .ForMember(x => x.Total, opt => opt.MapFrom(c => (c.Qty * c.Price) - c.Discount));
                //
                cfg.CreateMap<DoctorDto,Doctor>();
                cfg.CreateMap<Doctor, DoctorDto>()
                .ForMember(c => c.Country, opt => opt.MapFrom(c => c.CountryWork.Name))
                .ForMember(c => c.Speciality, opt => opt.MapFrom(c =>  c.MedicalSpecialityDoctor.Select(v=> new { Name=v.MedicalSpeciality.Name}).FirstOrDefault()));
                cfg.CreateMap<EventTypes, EventTypeDto>().ReverseMap();
                //

                cfg.CreateMap<PersonalSchedule, PersonalScheduleDto>().ReverseMap();
                cfg.CreateMap<PersonalSchedule, PersonalScheduleDto>()
                .ForMember(x => x.PatientName, opt => opt.MapFrom(x => x.Patient.Name))
                .ForMember(x => x.EventName, opt => opt.MapFrom(x => x.EventTypes.Name));
                //
                cfg.CreateMap<Appointment, AppointmentDto>().ReverseMap();
                cfg.CreateMap<Appointment, AppointmentDto>()
              .ForMember(x => x.OfficeName, opt => opt.MapFrom(x => x.Office.Name)).ForMember(x => x.PatientName, opt => opt.MapFrom(x => $"{x.Patient.Name} "))
              .ForMember(x => x.AppointmentStateName, opt => opt.MapFrom(x => $"{x.AppointmentState.Name} "));
                //
                cfg.CreateMap<MedicalSchedule, MedicalScheduleDto>().ReverseMap();
                cfg.CreateMap<MedicalSchedule, MedicalScheduleDto>()
              .ForMember(x => x.MedicalOfficeName, opt => opt.MapFrom(x => x.DoctorOffice.Name));
                //
                cfg.CreateMap<DoctorOffice, DoctorOfficeDto>().ReverseMap();
                cfg.CreateMap<DoctorOffice, DoctorOfficeDto>()
              .ForMember(x => x.MedicalCenterName, opt => opt.MapFrom(x => x.MedicalCenter.Name))
              .ForMember(x => x.DoctorName, opt => opt.MapFrom(x => $"{x.Doctor.Treament} {x.Doctor.Name}"));
                //
                cfg.CreateMap<Consultation, ConsultationDto>().ReverseMap();
                cfg.CreateMap<Consultation, ConsultationDto>()
              .ForMember(x => x.PatientName, opt => opt.MapFrom(x => $"{x.Patient.Name}"))
              .ForMember(x => x.ReasonDescription, opt => opt.MapFrom(x => x.ReasonConsultationObj.Key))
              .ForMember(x => x.OfficeName, opt => opt.MapFrom(x => x.DoctorOffice.Name));
                //
                cfg.CreateMap<Menu, MenuDto>().ReverseMap();
                cfg.CreateMap<Children, ChildrenDto>().ReverseMap();
                cfg.CreateMap<Children, ChildrenDto>();
                cfg.CreateMap<Menu, MenuDto>()
             .ForMember(x => x.children, opt => opt.Condition(v=> v.children.Count>0));
                //
                cfg.CreateMap<Patient, PatientDto>().ReverseMap();
                cfg.CreateMap<MedicalForm, MedicalFormDto>().ReverseMap();
                cfg.CreateMap<Doctor, DoctorDto>();
                //
                cfg.CreateMap<MedicalServices, MedicalServiceDto>().ReverseMap();
                cfg.CreateMap<MedicalServices, MedicalServiceDto>()
                .ForMember(x => x.ApplyInsuranceName, opt => opt.MapFrom(x => x.ApplyInsurance?"Si":"No"));

                //
                cfg.CreateMap<Prescription, PrescriptionDto>().ReverseMap();
                cfg.CreateMap<Prescription, PrescriptionDto>().ForMember(x => x.PatientName, opt => opt.MapFrom(x => x.Patient.Name));
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
