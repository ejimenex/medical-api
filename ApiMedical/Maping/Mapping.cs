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
            });
            IMapper mapper = config.CreateMapper();
            return mapper;
        }
    }
}
