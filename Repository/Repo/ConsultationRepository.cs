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
   public class ConsultationRepository : RepositoryBase<Consultation>
    {
        public ConsultationRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<Consultation> FindAll()
        {
            return base.FindAll().Include(c=> c.Patient).Include(c=> c.ReasonConsultationObj).Include(c=> c.DoctorOffice);
        }

    }
}
