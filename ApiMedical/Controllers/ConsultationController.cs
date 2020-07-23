using ApiMedical.Auth;
using ApiMedical.Common.Filter;
using AutoMapper;
using BussinesLogic.Interface;
using BussinesLogic.Interface.ListInterface;
using Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Dtos;

namespace ApiMedical.Controllers
{
    
    public class ConsultationController : BaseController<Consultation,ConsultationDto, IBaseService<Consultation>>
    {
        readonly IConsultationList consu;
        public ConsultationController(IBaseService<Consultation> manager, IMapper Mapper, IConsultationList _consu) : base(manager,Mapper)
        {
            consu = _consu;
        }
        [HttpGet]
        [AuthorizeMedical]
        [Route("GetConsultationPaginated")]
        public IActionResult GetMConsultationPaginated(ConsultationFilter resource)
        {
            var pagination = consu.GetPaged(resource);
            return Ok(pagination);
        }
    }
}