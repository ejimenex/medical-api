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
    //[Route("api/[controller]")]
    public class ArsController : BaseController<HealthManager,HealthManagerDto, IBaseService<HealthManager>>
    {
        public ArsController(IBaseService<HealthManager> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        //[EnableQuery]
        //[HttpGet]
       
        //public override IActionResult Get()
        //{
            
        //    return base.Get();
        //}
        [HttpGet("GetByCountry")]
        public  IActionResult GetByCountry([FromQuery]int Id)
        {
            try
            {
                var result = _service.FindByCondition(x => x.IsActive && x.CountryId == Id).Select(n=> new HealthManagerDto { 
                Id=n.Id,
                Name=n.Name
                });
                return Ok(_Mapper.Map<IEnumerable<HealthManagerDto>>(result));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
}