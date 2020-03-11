
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class PrescriptionService : BaseService<Prescription>
    {
        
        public PrescriptionService(IRepository<Prescription> repository) :base(repository)
        {
           
        }
        public override int Create(Prescription entity)
        {

            entity.Patient = null;
            entity.PrescriptionDate = DateTime.Now;
           
            return base.Create(entity);
        }
        public override Prescription Update(Prescription entity)
        {

            entity.Patient = null;
            return base.Update(entity);
        }


    }
}
