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
   public class PersonalScheduleRepository : RepositoryBase<PersonalSchedule>
    {
        public PersonalScheduleRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<PersonalSchedule> FindAll()
        {
            var result = base.FindAll().Include(c=> c.EventTypes).Include(c=> c.Patient);
            return result;
        }

    }
}
