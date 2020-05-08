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
   public class DoctorRepository : RepositoryBase<Doctor>
    {
        public DoctorRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<Doctor> FindAll()
        {
            var result = base.FindAll().Include(c=> c.CountryWork).Include(c=> c.MedicalSpecialityDoctor);
           return result;
        }

    }
}
