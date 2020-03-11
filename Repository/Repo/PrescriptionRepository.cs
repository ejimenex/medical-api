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
   public class PrescriptionRepository : RepositoryBase<Prescription>
    {
        public PrescriptionRepository(MedicalContext ctx) : base(ctx)
        {

        }

        public override IQueryable<Prescription> FindAll()
        {
            return base.FindAll().Include(c=> c.Patient);
        }
        public override IQueryable<Prescription> FindByCondition(Expression<Func<Prescription, bool>> expression)
        {
            return base.FindByCondition(expression).Include(c => c.Patient); 
        }
    }
}
