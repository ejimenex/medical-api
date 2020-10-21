using Entities;
using Entities.Entity.View;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class InvoiceNoFactRepository: IInvoiceNofactRepository
    {
        private readonly MedicalContext _medicalContext;
        public InvoiceNoFactRepository(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        public IEnumerable<VwInvoicesNoFact> GetByatient(int Patient) {
            return _medicalContext.Set<VwInvoicesNoFact>().Where(c => c.PatientId == Patient);
        }

    }
}
