using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class MedicalSchedule:BaseClass
    {
        public int? MedicalCenterId { get; set; }
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
      
        [ForeignKey("MedicalCenterId")]
       
        public virtual MedicalCenter MedicalCenter { get; set; }
     
    }
}
