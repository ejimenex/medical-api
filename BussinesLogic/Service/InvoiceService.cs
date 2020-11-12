
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;
using Entities.Entity.View;
using BussinesLogic.Interface;

namespace BussinesLogic.Service
{
  
    public class InvoiceService : BaseService<Invoice>, IInvoice
    {
        private readonly IRepository<Doctor> doctorRepository;
        private readonly IRepository<MedicalProcess> processRepository;
        private readonly IRepository<Consultation> consultationRepository;
        private readonly IInvoideDetail invoiceDetailRepository;
        public InvoiceService(IRepository<MedicalProcess> _processRepository,IRepository<Invoice> repository, IRepository<Doctor> _doctorRepository, IInvoideDetail _invoiceDetailRepository, IRepository<Consultation> _consultationRepository) : base(repository)
        {
            doctorRepository = _doctorRepository;
            invoiceDetailRepository = _invoiceDetailRepository;
            consultationRepository = _consultationRepository;
            processRepository = _processRepository;
        }
        public override int Create(Invoice entity)
        {
            entity.InvoiceNumber = GenerateInvoiceNumber(entity.PatientId, entity.DoctorGuid);
            entity.IsBilled = false;
            entity.Office = null;
            entity.Patient = null;
            var result = base.Create(entity);
            return result;
        }

        public void InvoiceAll(List<VwInvoicesNoFact> data,Invoice invoice)
        {
            var doctorGuid = doctorRepository.GetOne(data.FirstOrDefault().DoctorId).DoctorGuid;
            var invoiceHeader = new Invoice
            {
                DoctorGuid=doctorGuid,
                InvoiceNumber= GenerateInvoiceNumber(data.FirstOrDefault().PatientId, doctorGuid),
                PatientId= data.FirstOrDefault().PatientId,
                OfficeId = data.FirstOrDefault().OfficeId,                
                CreateBy= invoice.CreateBy
                
            };
            var result = base.Create(invoiceHeader);
            foreach (var item in data)
            {
                var newDetail = new InvoiceDetail { 
                InvoiceId=result,
                Qty=1,
                Price=item.Amount.Value,
                MedicalServiceId=item.ServiceId };
                invoiceDetailRepository.Add(newDetail);
                switch (item.Type)
                {
                    case "C":
                        var oneConsultation = consultationRepository.GetOne(item.IdRelative);
                        oneConsultation.ProcessStatusId = 2;
                        
                        consultationRepository.Update(oneConsultation);
                        break;
                    case "P":
                        var process = processRepository.GetOne(item.IdRelative);
                        process.ProcessStatus = 2;
                        processRepository.Update(process);
                        break;
                }
            };
        }
        public override Invoice Update(Invoice entity)
        {
            entity.Office = null;
            entity.Patient = null;
            if (entity.IsBilled) entity.BilledDate = DateTime.Now;
            return base.Update(entity);
        }
        private string GenerateInvoiceNumber(int? Patient, Guid? Dr)
        {
            var last = base.FindByCondition(c => c.PatientId == Patient && c.DoctorGuid == Dr && c.IsActive).OrderByDescending(c => c.Id);
            var digit = last == null ? 1 : last.Count();
            return $"F-{Patient}-{digit}";
        }

    }
}