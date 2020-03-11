using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMedical.Dtos;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class MedicalFormController : BaseController<MedicalForm,MedicalFormDto, IBaseService<MedicalForm>>
    {
        public MedicalFormController(IBaseService<MedicalForm> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [EnableQuery()]
        public override IActionResult Get()
        {           
            return base.Get();
        }
        [HttpGet]
        [Route("GetByDoctor/{id}")]
        public IActionResult GetByDoctor(Guid id)
        {
                return Ok(_service.FindByCondition(c=> c.DoctorGuid==id && c.IsActive).OrderByDescending(c=> c.NoOrder));
        }
    }
}