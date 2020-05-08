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
    public class UserController : BaseController<Users,UserDto, IBaseService<Users>>
    {
        public UserController(IBaseService<Users> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetUserPaginated")]
        public IActionResult GetUserPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll();
            if (resource.DoctorId != null)
                collection = collection.Where(v => v.DoctorId == resource.DoctorId);
             collection = collection.Where(x => x.Name.Contains(resource.parameters)
            || x.UserName.Contains(resource.parameters)
            || x.Mail.Contains(resource.parameters)
            || x.Role.RolName.Contains(resource.parameters));

           

            if (collection.Count() == 0)
                return NotFound();
            var dtos = _Mapper.ProjectTo<UserDto>(collection);
            var result = PagedList<UserDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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