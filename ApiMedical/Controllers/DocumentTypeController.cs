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
using Repository.Interface;

namespace ApiMedical.Controllers
{
   // [Route("api/[controller]")]
    public class DocumentTypeController : ODataController
    {
        readonly IGetData<DocumentType> repo;
        public DocumentTypeController(IGetData<DocumentType> _repo) 
        {
            repo = _repo;
        }
        [EnableQuery]
        [HttpGet]
        public  IActionResult Get()
        {
            try
            {
                var data = repo.GetData();
                return Ok(data);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }           
        }
    }
}