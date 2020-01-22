
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class MedicalScheduleService : BaseService<MedicalSchedule>
    {

        public MedicalScheduleService(IRepository<MedicalSchedule> repository):base(repository)
        {
          
        }
     

    }
}
