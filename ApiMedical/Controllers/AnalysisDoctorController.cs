﻿using ApiMedical.Common.Pagination;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiMedical.Controllers
{
    [Route("api/[controller]")]
    public class AnalysisDoctorController : BaseController<AnalysisDoctor,AnalysisDoctorDto, IBaseService<AnalysisDoctor>>
    {
        public AnalysisDoctorController(IBaseService<AnalysisDoctor> manager, IMapper Mapper) : base(manager,Mapper)
        {

        }
       
        [HttpGet]
        [Route("GetAnalysisPaginated")]
        public IActionResult GetAnalysisPaginated(ResourceParameters resource)
        {
            if (resource.parameters == null) resource.parameters = "";
            var collection = _service.FindAll().Where(x => x.Description.Contains(resource.parameters) && x.DoctorGuid==resource.DoctorGuid);

            if (collection.Count() == 0)
                return NotFound();
            var dtos = _Mapper.ProjectTo<AnalysisDoctorDto>(collection);
            var result = PagedList<AnalysisDoctorDto>.Create(dtos, resource.PageNumber, resource.PageSize);
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
        [HttpGet("GetByDoctor")]
        public  IActionResult GetByCountry([FromQuery]Guid DoctorGuid)
        {
            try
            {
                var result = _service.FindByCondition(x => x.IsActive && x.DoctorGuid == DoctorGuid).AsQueryable();
                return Ok(_Mapper.Map<IEnumerable<AnalysisDoctorDto>>(result));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }
    }
   
}