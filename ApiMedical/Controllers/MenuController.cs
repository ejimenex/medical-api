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
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        readonly IMenu menu;
        protected readonly IMapper _Mapper;
        public MenuController(IMenu _rol, IMapper Mapper) 
        {
            _Mapper = Mapper;
            menu = _rol;
        }
        [HttpGet("{id}")]
        public  IActionResult Get([FromRoute] int id)
        {
            try
            {
                var data = menu.GetMenu(id).Select(c => new Menu {
                    icon = c.icon,
                    name = c.name,
                    url=c.url,
                    display=c.display,
                    children = c.children.Select(v => new Children {
                        icon=v.icon,
                        name=v.name,
                        url=v.url,
                        display=v.display
                    }).OrderBy(v=> v.Order).ToList()
                });
                var dtos = _Mapper.Map<IEnumerable<MenuDto>>(data);
               
                return Ok(dtos);
            }
            catch (Exception e)
            {

                return NotFound(e.Message);
            }
           
        }
    }
}