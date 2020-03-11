﻿using System;
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
    public class PatientController : BaseController<Patient,PatientDto, IBaseService<Patient>>
    {
        public PatientController(IBaseService<Patient> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [EnableQuery()]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [HttpGet("getByDoctor")]
        [EnableQuery()]
        public IActionResult GetByDoctor(int Id)
        {
            return Ok( _service.FindByCondition(x=> x.DoctorId==Id).AsQueryable());
        }
        [HttpGet("allByDoctor")]
        [EnableQuery()]
        public IActionResult AllByDoctor(int Id)
        {
            return Ok(_service.FindByCondition(x => x.DoctorId == Id).OrderBy(C=> C.Name).AsQueryable());
        }
    }
}