
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BussinesLogic.Service
{
   public class PatientFormService : BaseService<PatientForm>
    {
        
        public PatientFormService(IRepository<PatientForm> repository):base(repository)
        {
            
        }


    }
}
