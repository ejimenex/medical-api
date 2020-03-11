
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Security.Cryptography;
using BussinesLogic.Interface;
using System.Linq;

namespace BussinesLogic.Service
{
   public class AccountService : BaseService<Users>,IAccount
    {
        
        public AccountService(IRepository<Users> repository):base(repository)
        {
        
        }

        public bool ChangePassword(string password,string OldPassword, string userName)
        {
            try
            {
                var pass = Common.Encript.GetSHA1(password);
                var data = this._repository.FindByCondition(c => c.UserName == userName).FirstOrDefault();
                if (data.Password != Common.Encript.GetSHA1(OldPassword))
                    throw new ArgumentException("notcoins");
                data.Password = pass;
                this._repository.Update(data);
                return true;
            }
            catch (Exception e)
            {
                throw new ArgumentException(e.Message);
            }
          
        }

        public Users VerifyUser(string password, string userName)
        {
            var pass = Common.Encript.GetSHA1(password);
            var data=this._repository.FindByCondition(c => c.Password == pass && c.UserName == userName).FirstOrDefault();
            if (data == null)
                throw new ArgumentException("Usuario no existe / User do not exist");
            if(data.IsLocked==true)
                throw new ArgumentException("Usuario bloqueado / Bloqued User");
            if (!data.IsActive)
                throw new ArgumentException("User is not active / Usuario no esta activo");
            if((data.IsProbatory!=null) && data.IsProbatory.Value &&  DateTime.Now > data.ExpireDateProbatory)
                throw new ArgumentException($"Trial period caduced on {data.ExpireDateProbatory.Value.ToString("yyyy-MM-dd")} / Periodo de prueba caduco el {data.ExpireDateProbatory.Value.ToString("yyyy-MM-dd")}");
            return data;
        }
    }
}
