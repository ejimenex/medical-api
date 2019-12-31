using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interface
{
   public interface IAccount
    {
        Users VerifyUser(string password, string userName);
        bool ChangePassword(string password, string userName);
        
    }
}
