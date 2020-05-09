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

    public class MedicalServiceController : BaseController<MedicalServices,MedicalServiceDto, IBaseService<MedicalServices>>
    {
        
        public MedicalServiceController(IBaseService<MedicalServices> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetByGuid")]
        public IActionResult GetByGuid(Guid id)
        {           
            var collection = _service.FindByCondition(x => x.DoctorGuid == id && x.IsActive).OrderBy(c=> c.Name);
            var dtos = _Mapper.ProjectTo<MedicalServiceDto>(collection);
            return Ok(dtos);
        }

        [HttpGet]
        [Route("GetMedicalServicePaginated")]
        public IActionResult GetMedicalServicePaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.DoctorGuid == resource.DoctorGuid);
              collection=collection.Where(c=>c.Name.Contains(resource.parameters));
            var dtos = _Mapper.ProjectTo<MedicalServiceDto>(collection);
            var result = PagedList<MedicalServiceDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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