using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class PermisionRepository : IPermission
    {
        readonly MedicalContext _medicalContext;
        public PermisionRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<Role> Get() {
            return _medicalContext.Role.AsQueryable();
        }

        public bool GetPermission(int RolId, int PermissionId)
        {
            var result= _medicalContext.PermissionRoles.Where(c => c.RolId == RolId && c.PermissionId == PermissionId).FirstOrDefault();
            if (result == null)
                return false;
            return result.HasPermission.Value;



        }
    }
}
