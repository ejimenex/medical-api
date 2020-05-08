using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class InvoiceDto : BaseDto

    {
        public Guid? DoctorGuid { get; set; }
        public string InvoiceNumber { get; set; }
        public int? PatientId { get; set; }
        public bool IsBilled { get; set; }
        public int? CurrencyId { get; set; }
        public int? MedicalCenterId { get; set; }
        public DateTime? BilledDate { get; set; }
        public string PatientName { get; set; }
        public string MedicalCenterName { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public int TotalItem { get; set; }

        
    }
}
