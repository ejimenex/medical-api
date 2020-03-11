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
    public class DoctorOfficeController : BaseController<DoctorOffice,DoctorOfficeDto, IBaseService<DoctorOffice>>
    {
        public DoctorOfficeController(IBaseService<DoctorOffice> manager, IMapper Mapper) : base(manager,Mapper)
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
            try
            {
                var data = _service.FindByCondition(x => x.DoctorId == Id).Select(c=> new DoctorOfficeDto{
                DoctorName=$"{c.Doctor.Treament} { c.Doctor.Name} {c.Doctor.SurName}",
                Specification=c.Specification,
                UrlMapsAddress=c.UrlMapsAddress,
                MedicalCenterName=c.MedicalCenter.Name,
                Name=c.Name,
                Id=c.Id
                }).AsQueryable();
                return Ok(_Mapper.Map<IEnumerable<DoctorOfficeDto>>(data));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        
        }
    }
}