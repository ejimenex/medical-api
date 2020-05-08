﻿using System;
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
  
    public class ConsultationController : BaseController<Consultation,ConsultationDto, IBaseService<Consultation>>
    {
        public ConsultationController(IBaseService<Consultation> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetConsultationPaginated")]
        public IActionResult GetMConsultationPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.DoctorId == resource.DoctorId);
            if (resource.datefrom.HasValue && resource.dateto.HasValue)
                collection = collection.Where(c => c.CreatedDate >= resource.datefrom && c.CreatedDate <= resource.dateto);
            collection = collection.Where(c => c.Patient.Name.Contains(resource.parameters)
            || c.DoctorOffice.Name.Contains(resource.parameters));
            var dtos = _Mapper.ProjectTo<ConsultationDto>(collection);
            var result = PagedList<ConsultationDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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