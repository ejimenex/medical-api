using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
   public interface IInvoideDetail
    {
        int Add(InvoiceDetail data);
        InvoiceDetail Edit(InvoiceDetail data);
        void Delete(int Id);
        IQueryable<InvoiceDetail> GetByInvoice(int InvoiceId);
    }
}
