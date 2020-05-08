using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class InvoiceDetailDto
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int MedicalServiceId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int? DiscountReasonId { get; set; }
        public string DiscountReason { get; set; }
        public string MedicalService { get; set; }
    }
}
