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
    public class CountryController : BaseController<Country,CountryDto, IBaseService<Country>>
    {
        public CountryController(IBaseService<Country> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [EnableQuery()]
        public override IActionResult Get()
        {
            return base.Get();
        }
    }
}