using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
  public class Invoice:BaseClass
    {
        public Guid? DoctorGuid { get; set; }
        public string InvoiceNumber { get; set; }
        public int? PatientId { get; set; }
        public bool IsBilled { get; set; }
        public int? CurrencyId { get; set; }
        public int? MedicalCenterId { get; set; }
        public DateTime? BilledDate { get; set; }
        [ForeignKey("MedicalCenterId")]
        public virtual MedicalCenter MedicalCenter { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        public virtual ICollection <InvoiceDetail> InvoiceDetail { get; set; }
    }
}
