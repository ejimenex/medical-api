using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class MedicalSpecialityDoctorRepository : RepositoryBase<MedicalSpecialityDoctor>
    {
        public MedicalSpecialityDoctorRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<MedicalSpecialityDoctor> FindAll()
        {
            return base.FindAll().Include(c => c.MedicalSpeciality);
        }
    }
}
