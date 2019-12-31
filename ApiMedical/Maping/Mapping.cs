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
               .ForMember(x => x.Country, opt => opt.MapFrom(x => x.CountryObj.Name));
                //
                cfg.CreateMap<Role, RoleDto>().ReverseMap();

            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
