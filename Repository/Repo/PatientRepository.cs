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
   public class PatientRepository : RepositoryBase<Patient>
    {
        public PatientRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<Patient> FindAll()
        {
            var result = base.FindAll();
            return result;
        }

    }
}
