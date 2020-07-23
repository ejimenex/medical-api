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

    public class MedicalScheduleController : BaseController<MedicalSchedule, MedicalScheduleDto, IBaseService<MedicalSchedule>>
    {
        public MedicalScheduleController(IBaseService<MedicalSchedule> manager, IMapper Mapper) : base(manager, Mapper)
        {

        }
        //[HttpGet]
        //[EnableQuery()]
        //public override IActionResult Get()
        //{

        //    return base.Get();
        //}
        [HttpGet("GetByDoctor")]
        public IActionResult GetByDoctor([FromQuery]int Id)
        {
            try
            {
                var result = _service.FindByCondition(x => x.IsActive && x.DoctorId == Id).Select
                    (c => new MedicalScheduleDto
                    {
                        Monday = c.Monday,
                        Wednesady = c.Wednesady,
                        Tuesday = c.Tuesday,
                        Thursday = c.Thursday,
                        Saturday = c.Saturday,
                        Friday = c.Friday,
                        Sunday = c.Sunday,
                        MaxQuantityMonday = c.MaxQuantityMonday,
                        MaxQuantityTuesday = c.MaxQuantityTuesday,
                        MaxQuantityWednesady = c.MaxQuantityWednesady,
                        MaxQuantityThursday = c.MaxQuantityThursday,
                        MaxQuantityFriday = c.MaxQuantityFriday,
                        MaxQuantitySaturday = c.MaxQuantitySaturday,
                        MaxQuantitySunday = c.MaxQuantitySunday,
                        MedicalOfficeName = c.DoctorOffice.Name,
                        Id = c.Id
                    });
                return Ok(_Mapper.Map<IEnumerable<MedicalScheduleDto>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("GetByOffice")]
        public IActionResult GetByOffice([FromQuery]int Id)
        {
            try
            {
                var result = _service.FindByCondition(x => x.IsActive && x.MedicalOfficeId == Id).Select
                    (c => new MedicalScheduleDto
                    {
                        Monday = c.Monday,
                        Wednesady = c.Wednesady,
                        Tuesday = c.Tuesday,
                        Thursday = c.Thursday,
                        Saturday = c.Saturday,
                        Friday = c.Friday,
                        Sunday = c.Sunday,
                        MaxQuantityMonday = c.MaxQuantityMonday,
                        MaxQuantityTuesday = c.MaxQuantityTuesday,
                        MaxQuantityWednesady = c.MaxQuantityWednesady,
                        MaxQuantityThursday = c.MaxQuantityThursday,
                        MaxQuantityFriday = c.MaxQuantityFriday,
                        MaxQuantitySaturday = c.MaxQuantitySaturday,
                        MaxQuantitySunday = c.MaxQuantitySunday,
                        MedicalOfficeName = c.DoctorOffice.Name,
                        Id = c.Id
                    });
                return Ok(_Mapper.Map<IEnumerable<MedicalScheduleDto>>(result));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}