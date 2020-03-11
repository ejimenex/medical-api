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
using Repository.Interface;

namespace ApiMedical.Controllers
{
    //[Route("api/[controller]")]
    public class CurrencyController : ODataController
    {
        readonly ICurrency curr;
        protected readonly IMapper _Mapper;
        public CurrencyController(ICurrency _curr, IMapper Mapper) 
        {
            _Mapper = Mapper;
            curr = _curr;
        }
        [EnableQuery]
        [HttpGet]
        public  ActionResult<IEnumerable<Currency>> Get()
        {
            try
            {
                var data = curr.GetAll();
                return Ok(data);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
           
        }
    }
}