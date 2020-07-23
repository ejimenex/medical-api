﻿using System;
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

namespace ApiMedical.Controllers
{
   
    public class MedicalFormController : BaseController<MedicalForm,MedicalFormDto, IBaseService<MedicalForm>>
    {
        public MedicalFormController(IBaseService<MedicalForm> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
        [HttpGet]
        [Route("GetMedicalQuestionPaginated")]
        public IActionResult GetMedicalQuestionPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.DoctorGuid == resource.DoctorGuid);
            collection = collection.Where(c => c.Question.Contains(resource.parameters));
            var dtos = _Mapper.ProjectTo<MedicalFormDto>(collection);
            var result = PagedList<MedicalFormDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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
        [HttpGet]
        [Route("GetByDoctor/{id}")]
        public IActionResult GetByDoctor(Guid id)
        {
                return Ok(_service.FindByCondition(c=> c.DoctorGuid==id && c.IsActive).OrderByDescending(c=> c.NoOrder));
        }
    }
}