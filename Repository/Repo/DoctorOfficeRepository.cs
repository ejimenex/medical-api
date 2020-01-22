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
   public class DoctorOfficeRepository : RepositoryBase<DoctorOffice>
    {
        public DoctorOfficeRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<DoctorOffice> FindAll()
        {
            var result = RepositoryContext.DoctorOffice.Where(x=> x.IsActive).Include(c=> c.Doctor).Include(c=> c.MedicalCenter).AsQueryable();
            return result;
        }

    }
}
