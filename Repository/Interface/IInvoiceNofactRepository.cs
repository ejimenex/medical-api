using Entities.Entity.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
   public interface IInvoiceNofactRepository
    {
        IEnumerable<VwInvoicesNoFact> GetByatient(int Patient);
    }
}
