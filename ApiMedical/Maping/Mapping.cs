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

                cfg.CreateMap<Doctor, DoctorDto>().ReverseMap();
                //
                cfg.CreateMap<MedicalSchedule, MedicalScheduleDto>().ReverseMap();
                cfg.CreateMap<MedicalSchedule, MedicalScheduleDto>()
              .ForMember(x => x.MedicalCenterName, opt => opt.MapFrom(x => x.MedicalCenter.Name));
                //
                cfg.CreateMap<DoctorOffice, DoctorOfficeDto>().ReverseMap();
                cfg.CreateMap<DoctorOffice, DoctorOfficeDto>()
              .ForMember(x => x.MedicalCenterName, opt => opt.MapFrom(x => x.MedicalCenter.Name))
              .ForMember(x => x.DoctorName, opt => opt.MapFrom(x => $"{x.Doctor.Treament} {x.Doctor.Name}"));
                //

                cfg.CreateMap<Patient, PatientDto>().ReverseMap();
                cfg.CreateMap<Doctor, DoctorDto>();
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
