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
using Microsoft.EntityFrameworkCore;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class PatientFormController : BaseController<PatientForm,PatientFormDto, IBaseService<PatientForm>>
    {
        public PatientFormController(IBaseService<PatientForm> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("filtered/{id}/{patientid}")]
        public IActionResult GetFiltered(Guid id, int patientid)
        {
            var data = _service.FindByCondition(c => c.DoctorGuid == id && c.PatientId == patientid)
                .Include(c=> c.MedicalForm)
                .OrderBy(c=> c.MedicalForm.NoOrder);
            var result = _Mapper.Map<IEnumerable <PatientFormDto>>(data);
            return Ok(result
                );
        }
    }
}