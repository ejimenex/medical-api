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
using ApiMedical.Common.Pagination;
using ApiMedical.Auth;

namespace ApiMedical.Controllers
{
    //[Route("api/[controller]")]
    public class PatientController : BaseController<Patient,PatientDto, IBaseService<Patient>>
    {
        public PatientController(IBaseService<Patient> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetPatientPaginated")]
        [AuthorizeMedical]
        public IActionResult GetPatientPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.DoctorId == resource.DoctorId);

            collection = collection.Where(c => c.Name.Contains(resource.parameters)
            || c.Phone.Contains(resource.parameters));
            var dtos = _Mapper.ProjectTo<PatientDto>(collection);
            var result = PagedList<PatientDto>.Create(dtos, resource.PageNumber, resource.PageSize);
            var pagination = new
            {
                totalCount = result.TotalCount,
                pageSize = result.PageSize,
                currentPage = result.CurrentPage,
                totalPage = result.TotalPages,
                HasNext = result.HasNext,
                HasPrevious = result.HasPrevious,
                data = result
            };
            return Ok(pagination);
        }
        [HttpGet("getByDoctor")]
        [EnableQuery()]
        public IActionResult GetByDoctor(int Id)
        {
            return Ok( _service.FindByCondition(x=> x.DoctorId==Id).AsQueryable());
        }
        [HttpGet("allByDoctor")]
        [AuthorizeMedical]
        public IActionResult AllByDoctor(int Id)
        {
            return Ok(_service.FindByCondition(x => x.DoctorId == Id).OrderBy(C=> C.Name).AsQueryable());
        }
    }
}