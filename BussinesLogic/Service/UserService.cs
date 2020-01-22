
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Security.Cryptography;
using BussinesLogic.Common;

namespace BussinesLogic.Service
{
   public class UserService:BaseService<Users>
    {
        
        public UserService(IRepository<Users> repository):base(repository)
        {
        
        }
        public override int Create(Users entity)
        {
            var exist = _repository.Exist(x => x.UserName == entity.UserName && x.IsActive);
            if (exist) throw new ArgumentException("lUserExist");

            entity.Password = Encript.GetSHA1(entity.Password);

            if (entity.IsProbatory.Value)
                entity.ExpireDateProbatory = DateTime.Now.AddMonths(1);

            return base.Create(entity);
        }

    }
}
