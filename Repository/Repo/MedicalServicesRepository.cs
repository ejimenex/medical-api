using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repo
{
   public class MedicalServicesRepository : RepositoryBase<MedicalServices>
    {
        public MedicalServicesRepository(MedicalContext ctx) : base(ctx)
        {

        }

       
        public override IQueryable<MedicalServices> FindByCondition(Expression<Func<MedicalServices, bool>> expression)
        {
            return base.FindByCondition(expression); 
        }
    }
}
