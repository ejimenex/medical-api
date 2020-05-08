using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
    public class DiscountReasonRepository : IDiscountReason
    {
        private readonly MedicalContext _ctx;
        public DiscountReasonRepository(MedicalContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<InvoiceDiscountReason> GetAll()
        {
            return _ctx.InvoiceDiscountReason.AsQueryable();
        }
    }
}
