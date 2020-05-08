using Entities;
using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repo
{
   public class InvoiceDetailRepository:IInvoideDetail

    {
        private readonly MedicalContext _ctx;
        public InvoiceDetailRepository(MedicalContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<InvoiceDetail> GetByInvoice(int InvoiceId)
        {
            return _ctx.InvoiceDetail.Where(c => c.InvoiceId == InvoiceId).Include(c => c.MedicalService);
        }
        public int Add(InvoiceDetail data)
        {
            try
            {
                 var detail= _ctx.Add(data);
                return _ctx.SaveChanges();
                    
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public InvoiceDetail Edit(InvoiceDetail data)
        {
            try
            {
               var _data= _ctx.InvoiceDetail.Find(data.Id);
                _data = data;
                _ctx.SaveChanges();
                return data;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void Delete(int Id)
        {
            _ctx.Remove(_ctx.InvoiceDetail.Find(Id));
            _ctx.SaveChanges();
        }

    }
}
