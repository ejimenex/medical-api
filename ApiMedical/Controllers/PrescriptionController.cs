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
    public class PrescriptionController : BaseController<Prescription,PrescriptionDto, IBaseService<Prescription>>
    {
        
        public PrescriptionController(IBaseService<Prescription> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [EnableQuery()]
        public override IActionResult Get()
        {
            return base.Get();
        }
        [HttpGet("{id}/{doctorId}")]
        [EnableQuery()]
        public IActionResult GetByDoctor(int id, int doctorId)
        {
            try
            {
                var result = _service.FindByCondition(x => x.PatientId == id && x.DoctorId == doctorId).AsQueryable();
                var dto=_Mapper.Map<IEnumerable<PrescriptionDto>>(result);
                return Ok(dto);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
}