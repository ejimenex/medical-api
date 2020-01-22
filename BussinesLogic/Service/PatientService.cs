
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class PatientService : BaseService<Patient>
    {
        
        public PatientService(IRepository<Patient> repository):base(repository)
        {
        
        }
        public override int Create(Patient entity)
        {
            if (entity.ArsId == 0) entity.ArsId = null;

            return base.Create(entity);
        }


    }
}
