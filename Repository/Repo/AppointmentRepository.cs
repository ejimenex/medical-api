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
   public class AppointmentRepository : RepositoryBase<Appointment>
    {
        public AppointmentRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<Appointment> FindAll()
        {
            var result = base.FindAll()
                .Include(c=> c.Patient)
                .Include(c=> c.Office)
                .Include(c=> c.AppointmentState)
                .AsQueryable();
            return result;
        }

    }
}
