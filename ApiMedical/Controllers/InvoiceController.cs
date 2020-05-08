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

    public class InvoiceController : BaseController<Invoice,InvoiceDto, IBaseService<Invoice>>
    {
        public InvoiceController(IBaseService<Invoice> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetInvoicePaginated")]
        public IActionResult  GetInvoicePaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.DoctorGuid == resource.DoctorGuid);
            if (collection.Count() == 0)
                return BadRequest("No Data");
            collection = collection.Where(c => c.Patient.Name.Contains(resource.parameters)
            || c.MedicalCenter.Name.Contains(resource.parameters));
            var dtos = _Mapper.ProjectTo<InvoiceDto>(collection);
            var result =  PagedList<InvoiceDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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
            return Ok( pagination);
        }
       
    }
}