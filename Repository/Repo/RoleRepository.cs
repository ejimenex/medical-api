using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class RoleRepository:IRole
    {
        readonly MedicalContext _medicalContext;
        public RoleRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<Role> Get() {
            return _medicalContext.Role.AsQueryable();
        }
   
    }
}
