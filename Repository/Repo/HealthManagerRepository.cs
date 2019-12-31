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
   public class HealthManagerRepository : RepositoryBase<HealthManager>
    {
        public HealthManagerRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<HealthManager> FindAll()
        {
            return base.FindAll().Include(c=> c.CountryObj);
        }

    }
}
