using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class MedicalServiceDto:BaseDto
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool ApplyInsurance { get; set; }
        public string ApplyInsuranceName { get; set; }
        public decimal InsurancePrice { get; set; }
        public Guid DoctorGuid { get; set; }
        public string CurrencyId { get; set; }
    }
}
