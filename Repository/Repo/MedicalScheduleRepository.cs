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
   public class MedicalScheduleRepository : RepositoryBase<MedicalSchedule>
    {
        public MedicalScheduleRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<MedicalSchedule> FindAll()
        {
            return base.FindAll().Include(c=> c.DoctorOffice);
        }
        public override int Create(MedicalSchedule entity)
        {
            entity.DoctorOffice = null;
            return base.Create(entity);
        }
        public override MedicalSchedule Update(MedicalSchedule entity)
        {
            entity.DoctorOffice = null;
            return base.Update(entity);
        }
    }
}
