using Entities.Entity;
using Entities.Entity.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLogic.Interface
{
    public interface IInvoice
    {
        void InvoiceAll(List<VwInvoicesNoFact> data,Invoice invoice);
    }
}
