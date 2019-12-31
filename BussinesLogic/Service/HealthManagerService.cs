
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class HealthManagerService : BaseService<HealthManager>
    {
        
        public HealthManagerService(IRepository<HealthManager> repository):base(repository)
        {
        
        }
        public override int Create(HealthManager entity)
        {
            var exist = _repository.Exist(x => x.Name == entity.Name && x.IsActive && x.CountryId==entity.CountryId);
            if (exist) throw new ArgumentException("l.exist");
            return base.Create(entity);
        }


    }
}
