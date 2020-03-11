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
   public class DocumentRepository : RepositoryBase<Documents>
    {
        public DocumentRepository(MedicalContext ctx) : base(ctx) {

        }
        public override IQueryable<Documents> FindAll()
        {
            return base.FindAll().Include(c=> c.DocumentType);
        }

    }
}
