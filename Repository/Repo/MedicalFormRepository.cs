using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class MedicalFormRepository : RepositoryBase<MedicalForm>
    {
        public MedicalFormRepository(MedicalContext ctx) : base(ctx) {

        }
   
    }
}
