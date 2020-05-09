using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class InvoiceDetail
    {
        [Key]
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public int MedicalServiceId { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Discount{get;set;}
     
        [NotMapped]
        public decimal Total { get; set; }
      
        public int? DiscountReasonId { get; set; }
        [ForeignKey("MedicalServiceId")]
        public virtual MedicalServices MedicalService { get; set; }

        [ForeignKey("DiscountReasonId")]
        public virtual InvoiceDiscountReason DiscountReason { get; set; }

    }
   
}
