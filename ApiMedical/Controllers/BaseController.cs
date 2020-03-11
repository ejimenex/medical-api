using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BussinesLogic.Interface;
using Entities.Entity;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;

namespace ApiMedical.Controllers
{
   // [Route("api/[controller]")]
   
    public class BaseController<TEntity, TDto, TManager> : ODataController where TEntity : BaseClass where TManager : IBaseService<TEntity>
    {

        protected readonly TManager _service;

    protected readonly IMapper _Mapper;

    public BaseController(TManager manager, IMapper mapper)
        {
            _service = manager;
            _Mapper = mapper;

        }
        [EnableQuery]
        [HttpGet]
        public virtual IActionResult Get()
        {
            try
            {
                var objects = _service.FindAll().OrderByDescending(x=> x.Id);
                var dtos = _Mapper.Map<IEnumerable<TDto>>(objects);
                return Ok(dtos);
            }
            catch (Exception e)
            {

                return BadRequest("Internal Error");
            }
        
        }

        [HttpPost]
        public virtual IActionResult Post([FromBody] TDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                    throw new ArgumentException(messages);
                }
                TEntity entity = _Mapper.Map<TEntity>(dto);
                return Ok(_service.Create(entity));
            }
           
            catch (ArgumentException e)
            {
                return BadRequest( e.Message);
            }
        }
        [HttpDelete("{id}")]
        public virtual IActionResult Delete(int Id)
        {
            try
            {
              
                _service.Delete(Id);
                return Ok();
            }

            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
        [HttpGet("{id}")]
        public virtual IActionResult Get([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var entity = _service.GetOne(id);

                if (entity == null)
                {
                    return NotFound();
                }
                TDto dto = _Mapper.Map<TDto>(entity);
                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public virtual IActionResult Put([FromBody] TDto dto)
        {
            try
            {
                TEntity entity = _Mapper.Map<TEntity>(dto);
                _service.Update(entity);
                return NoContent();
            }

            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
