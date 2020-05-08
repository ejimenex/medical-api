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
    public class EventTypeController : BaseController<EventTypes,EventTypeDto, IBaseService<EventTypes>>
    {
        public EventTypeController(IBaseService<EventTypes> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        //[HttpGet]
        //[EnableQuery()]
        //public override IActionResult Get()
        //{
        //    return base.Get();
        //}
        [HttpGet("getByDoctor")]
        [EnableQuery()]
        public IActionResult GetByDoctor(int Id)
        {
            return Ok( _service.FindByCondition(x=> x.DoctorId==Id).AsQueryable());
        }
    }
}