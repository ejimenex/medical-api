using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
   public interface IPermission
    {
        bool GetPermission(int RolId, int PermisionId);
    }
}
