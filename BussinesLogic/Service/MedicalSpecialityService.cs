
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class MedicalSpecialityService : BaseService<MedicalSpeciality>
    {
        
        public MedicalSpecialityService(IRepository<MedicalSpeciality> repository):base(repository)
        {
        
        }
      


    }
}
