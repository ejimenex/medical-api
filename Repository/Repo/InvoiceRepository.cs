using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
    public class InvoiceRepository:RepositoryBase<Invoice>
    {
        public InvoiceRepository(MedicalContext ctx):base(ctx)
        {

        }
        public override IQueryable<Invoice> FindAll()
        {
            return base.FindAll().Include(c=> c.Patient).Include(c=> c.Office).Include(c=> c.InvoiceDetail);
        }
    }
}
