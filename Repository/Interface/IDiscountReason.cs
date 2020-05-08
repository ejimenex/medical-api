using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities.Entity;

namespace Repository.Interface
{
    public interface IDiscountReason
    {
        IQueryable<InvoiceDiscountReason> GetAll();
    }
}
