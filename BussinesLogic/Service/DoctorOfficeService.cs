
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class DoctorOfficeService : BaseService<DoctorOffice>
    {
        
        public DoctorOfficeService(IRepository<DoctorOffice> repository):base(repository)
        {
        
        }
        public override int Create(DoctorOffice entity)
        {
            entity.Doctor = null;
            entity.MedicalCenter = null;
            var exist = _repository.Exist(x => x.Name == entity.Name && x.IsActive);
            if (exist) throw new ArgumentException("l.exist");
            return base.Create(entity);
        }
        public override DoctorOffice Update(DoctorOffice entity)
        {
            entity.Doctor = null;
            entity.MedicalCenter = null;
            return base.Update(entity);
        }

    }
}
