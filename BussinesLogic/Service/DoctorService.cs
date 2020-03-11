
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class DoctorService:BaseService<Doctor>
    {
        public IRepository<MedicalSpecialityDoctor> me;
        public IRepository<Users> user;
        public DoctorService(IRepository<Doctor> repository, IRepository<Users> _user, IRepository<MedicalSpecialityDoctor> _me):base(repository)
        {
            me = _me;
            user = _user;
        }
        public override void Delete(int Id)
        {
            var userId = base.GetOne(Id);
            base.Delete(Id);
            var user_ = user.FindByCondition(c => c.DoctorId == userId.Id).FirstOrDefault();
            user.Delete (user_.Id);
        }
        public override int Create(Doctor entity)
        {
            try
            {if (user.Exist(c => c.UserName == entity.Users.UserName && c.IsActive))
                    throw new ArgumentException("lUserExist");
                entity.DoctorGuid= Guid.NewGuid();
                var result= base.Create(entity);
                if (entity.MedicalSpecialityDoctor != null) {
                    foreach (var ite in entity.MedicalSpecialityDoctor)
                    {
                        ite.DoctorId = result;
                        ite.CreateBy = entity.CreateBy;
                        me.Create(ite);
                    }
                }
              
                var newUser =entity.Users;
                newUser.RolId = 2;
                newUser.DoctorId = result;
                newUser.Mail = entity.Mail;
                newUser.Password = Common.Encript.GetSHA1(entity.Users.Password);
                newUser.IsLocked = false;
                newUser.Name = entity.Name;
                newUser.SurName = entity.SurName;
                user.Create(newUser);
                return result;
            }
            catch (Exception e)
            {

                throw new ArgumentException(e.Message);
            }
          ;
        }


    }
}
