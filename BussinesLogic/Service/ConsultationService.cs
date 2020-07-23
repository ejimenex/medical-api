using ApiMedical.Common.Filter;
using ApiMedical.Common.Pagination;
using AutoMapper;
using BussinesLogic.Interface.ListInterface;
using Entities.Entity;
using Repository.Dtos;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLogic.Service
{
    public class ConsultationService : BaseService<Consultation>, IConsultationList
    {
        readonly IRepository<Appointment> app;
        readonly IMapper mapper;
        public ConsultationService(IRepository<Consultation> repository, IRepository<Appointment> _app, IMapper _mapper) : base(repository)
        {
            app = _app;
            mapper = _mapper;
        }
        public override int Create(Consultation entity)
        {
            entity.Patient = null;
            entity.DoctorOffice = null;
            entity.ReasonConsultationObj = null;
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
            var collection = base.FindByCondition(x => x.DoctorId == resource.DoctorId);
            collection = resource.PatientId.HasValue ?collection=collection.Where(c => c.PatientId == resource.PatientId) :collection;
            if (collection.Count() == 0) throw new ArgumentException("");
            collection = resource.datefrom.HasValue && resource.dateto.HasValue ? collection = collection.Where(c => c.CreatedDate >= resource.datefrom && c.CreatedDate <= resource.dateto) : collection;
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
                List = data.OrderByDescending(c => c.CreatedDate)
            };
            return pagination;
        
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
