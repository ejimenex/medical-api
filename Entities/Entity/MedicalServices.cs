using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class MedicalServices : BaseClass
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool ApplyInsurance { get; set; }
        public decimal InsurancePrice { get; set; }
        public Guid DoctorGuid {get;set;}
        public string CurrencyId { get; set; }
        public bool? IsBasicConsultation { get; set; }
    }
}
