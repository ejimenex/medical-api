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
   public class MedicalCenterRepository : RepositoryBase<MedicalCenter>
    {
        public MedicalCenterRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<MedicalCenter> FindAll()
        {
            return base.FindAll().Include(c => c.CountryObj);
        }
    }
}
