using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class MedicalSpecialityRepository : RepositoryBase<MedicalSpeciality>
    {
        public MedicalSpecialityRepository(MedicalContext ctx) : base(ctx) {

        }
   
    }
}
