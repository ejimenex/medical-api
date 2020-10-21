
using ApiMedical.Common.Filter;
using ApiMedical.Common.Pagination;
using AutoMapper;
using BussinesLogic.Interface.ListInterface;
using Entities.Entity;
using Repository.Dtos;
using Repository.Interface;
using System;
using System.Linq;
using System.Web.Http;

namespace BussinesLogic.Service
{
    public class MedicalProcessService : BaseService<MedicalProcess>, IMedicalProcess
    {
        private readonly IMapper mapper;
        public MedicalProcessService(IRepository<MedicalProcess> repository, IMapper _mapper):base(repository)
        {
            mapper = _mapper;
        }
        public override int Create(MedicalProcess entity)
        {
            entity.Patient = null;
            entity.Service = null;
            entity.ServiceTypeObj = null;
            entity.MedicalProcessStatus = null;
            entity.DoctorOffice = null;
            entity.ServiceType = 2;
            entity.ProcessStatus = 1;
            return base.Create(entity);
        }

        public PagedData<MedicalProcessDto> GetPaged(MedicalProcessFilter resource)
        {

            var collection = base.FindByCondition(x => x.DoctorId == resource.DoctorId);
            if (collection.Count() == 0) throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            collection = resource.DateFrom.HasValue && resource.ToDate.HasValue ? collection = collection.Where(c => c.CreatedDate >= resource.DateFrom && c.CreatedDate <= resource.ToDate) : collection;
             collection = resource.PatientName != null ? collection = collection.Where(c => c.Patient.Name.Contains(resource.PatientName)) : collection;
            if (collection.Count() == 0) return new PagedData<MedicalProcessDto>();

            var list = mapper.ProjectTo<MedicalProcessDto>(collection);
            var data = PagedList<MedicalProcessDto>.Create(list.AsQueryable(), resource.PageNumber, resource.PageSize);

            var pagination = new PagedData<MedicalProcessDto>
            {

                TotalCount = data.TotalCount,
                PageSize = data.PageSize,
                CurrentPage = data.CurrentPage,
                TotalPages = data.TotalPages,
                Data = data.OrderByDescending(c => c.CreatedDate)
            };
            return pagination; throw new System.NotImplementedException();
        }

        public override MedicalProcess Update(MedicalProcess entity)
        {
            entity.Patient = null;
            entity.Service = null;
            entity.ServiceTypeObj = null;
            entity.MedicalProcessStatus = null;
            return base.Update(entity);
        }
    }
}
