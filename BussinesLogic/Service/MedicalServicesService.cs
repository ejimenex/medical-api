
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class MedicalServicesService : BaseService<MedicalServices>
    {
        
        public MedicalServicesService(IRepository<MedicalServices> repository):base(repository)
        {
        
        }
        public override int Create(MedicalServices entity)
        {
            var exist = _repository.Exist(x => x.Name == entity.Name && x.IsActive && x.DoctorGuid==entity.DoctorGuid);
            if (exist) throw new ArgumentException("l.exist");
            return base.Create(entity);
        }


    }
}
