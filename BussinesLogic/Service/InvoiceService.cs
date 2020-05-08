
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class InvoiceService : BaseService<Invoice>
    {
        public InvoiceService(IRepository<Invoice> repository) :base(repository)
        {
          
        }
        public override int Create(Invoice entity)
        {
            entity.InvoiceNumber = GenerateInvoiceNumber(entity.PatientId, entity.DoctorGuid);
            entity.IsBilled = false;          
            var result=base.Create(entity);          
            return result;
        }
        private string GenerateInvoiceNumber(int? Patient, Guid? Dr)
        {
            var last = base.FindByCondition(c => c.PatientId == Patient && c.DoctorGuid == Dr && c.IsActive).OrderByDescending(c => c.Id);
            var digit = last == null ? 1 : last.Count();
            return $"F-{Patient}-{digit}";
        }

    }
}