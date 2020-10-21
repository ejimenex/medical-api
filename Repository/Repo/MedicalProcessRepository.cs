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
    public class MedicalProcessRepository:RepositoryBase<MedicalProcess>
    {
        public MedicalProcessRepository(MedicalContext ctx):base(ctx)
        {
        }
        public override IQueryable<MedicalProcess> FindAll()
        {
            return base.FindAll()
                .Include(c=> c.ServiceTypeObj)
                .Include(c=> c.ProcessStatus)
                .Include(c=> c.Patient)
                .Include(c=> c.Service);  
        }

    }
}
