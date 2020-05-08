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
using ApiMedical.Pagination;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : BaseController<Doctor,DoctorDto, IBaseService<Doctor>>
    {
        public DoctorController(IBaseService<Doctor> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetDoctorPaginated")]
        public IActionResult GetDoctorPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.Name.Contains(resource.parameters) 
            || x.CountryWork.Name.Contains(resource.parameters));
           
            var dtos = _Mapper.ProjectTo<DoctorDto>(collection);
            var result = PagedList<DoctorDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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
    }
}