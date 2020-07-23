using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class MedicalCenterDto:BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int CountryId { get; set; }
        public string LogoPath { get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Slogan { get; set; }
        public CountryDto Country { get; set; }
        public string CountryName { get; set; }
    }
}
