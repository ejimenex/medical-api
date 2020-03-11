using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Dtos
{
   public class MedicalScheduleDto:BaseDto
    {
        public int? MedicalOfficeId { get; set; }
        public int? DoctorId { get; set; }
        public string Monday { get; set; }
        public int? MaxQuantityMonday { get; set; }
        public string Tuesday { get; set; }
        public int? MaxQuantityTuesday { get; set; }
        public string Wednesady { get; set; }
        public int? MaxQuantityWednesady { get; set; }
        public string Thursday { get; set; }
        public int? MaxQuantityThursday { get; set; }
        public string Friday { get; set; }
        public int? MaxQuantityFriday { get; set; }
        public string Saturday { get; set; }
        public int? MaxQuantitySaturday { get; set; }
        public string Sunday { get; set; }
        public int? MaxQuantitySunday { get; set; }
      
        public string MedicalOfficeName { get; set; }
        public DoctorOfficeDto DoctorOffice { get; set; }
    }
}
