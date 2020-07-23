using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Repository.Dtos;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class MedicalSpecialityController : BaseController<MedicalSpeciality,MedicalSpecialityDto, IBaseService<MedicalSpeciality>>
    {
        public MedicalSpecialityController(IBaseService<MedicalSpeciality> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        //[HttpGet]
        //[EnableQuery()]
        //public override IActionResult Get()
        //{
           
        //    return base.Get();
        //}
    }
}