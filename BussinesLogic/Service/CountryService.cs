
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class CountryService:BaseService<Country>
    {
        
        public CountryService(IRepository<Country> repository):base(repository)
        {
        
        }
        public override int Create(Country entity)
        {
            var exist = _repository.Exist(x => x.Name == entity.Name && x.IsActive);
            if (exist) throw new ArgumentException("l.exist");
            return base.Create(entity);
        }


    }
}
