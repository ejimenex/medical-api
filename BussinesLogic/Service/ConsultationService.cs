using ApiMedical.Common.Filter;
using ApiMedical.Common.Pagination;
using ApiMedical.Common.Token;
using AutoMapper;
using BussinesLogic.Interface.ListInterface;
using Entities.Entity;
using Repository.Dtos;
using Repository.Interface;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace BussinesLogic.Service
{
    public class ConsultationService : BaseService<Consultation>, IConsultationList
    {
        readonly IRepository<Appointment> app;
        readonly IRepository<Users> userRepository;
        private readonly ITokenService tokenService;
        readonly IMapper mapper;
        public ConsultationService(IRepository<Consultation> repository, IRepository<Users> _userRepository, ITokenService tokenService, IRepository<Appointment> _app, IMapper _mapper) : base(repository)
        {
            this.userRepository = _userRepository;
            app = _app;
            mapper = _mapper;
            this.tokenService = tokenService;
        }
        public override int Create(Consultation entity)
        {
            entity.Patient = null;
            entity.DoctorOffice = null;
            entity.ReasonConsultationObj = null;
            entity.ProcessStatusId = 1;
            entity.ConsultationNumber = $"C-{base.FindByCondition(c=>c.DoctorId==entity.DoctorId).Count()+1}";
            var dateNow = Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd"));
            var appointment = app.FindByCondition(c => c.PatientId == entity.PatientId && c.OfficeId == entity.OfficeId
            && c.Date == dateNow && c.AppointmentStateId==4)
                .FirstOrDefault();
            if (appointment != null)
            {  appointment.AppointmentStateId = 2;
                app.Update(appointment);
            }
            return base.Create(entity);
        }

        public PagedData<ConsultationDto> GetPaged(ConsultationFilter resource)
        {
            
            var collection = base.FindByCondition(x => x.DoctorGuid == resource.DoctorGuid);
            collection = resource.PatientId.HasValue ?collection=collection.Where(c => c.PatientId == resource.PatientId) :collection;
            if (collection.Count() == 0) throw new ArgumentException("");
            collection = resource.DateFrom.HasValue && resource.DateTo.HasValue ? collection = collection.Where(c => c.CreatedDate >= resource.DateFrom && c.CreatedDate <= resource.DateTo) : collection;
            collection = resource.PatientName!=null ? collection = collection.Where(c => c.Patient.Name.Contains(resource.PatientName)) : collection;
            collection = resource.OfficeName != null ? collection = collection.Where(c => c.DoctorOffice.Name.Contains(resource.OfficeName)) : collection;
            if (collection.Count() == 0) return new PagedData<ConsultationDto>();

            var list = mapper.ProjectTo<ConsultationDto>(collection);
            var data = PagedList<ConsultationDto>.Create(list.AsQueryable(), resource.PageNumber, resource.PageSize);

            var pagination = new PagedData<ConsultationDto>
            {

                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                CurrentPage = data.CurrentPage,
                TotalPages = data.TotalPages,
                Data = data.OrderByDescending(c => c.CreatedDate)
            };
            return pagination;
        
    }

        public  override  Consultation GetOne(int Id)
        {
            var t = this.tokenService.GetCurrentUser();
            var user = this.userRepository.FindByCondition(c => c.UserName == t && c.IsActive).FirstOrDefault();

            var result=  base.GetOne(Id);

            if (result.DoctorId != user.DoctorId)
                throw new HttpResponseException(System.Net.HttpStatusCode.Forbidden);

            return result;

        }
        public override Consultation Update(Consultation entity)
        {
            entity.Patient = null;
            entity.DoctorOffice = null;
            entity.ReasonConsultationObj = null;
            return base.Update(entity);
        }
    }
}
