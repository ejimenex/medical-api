using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class DoctorOffice:BaseClass
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public string UrlMapsAddress { get; set; }
        public int DoctorId { get; set; }
        public int MedicalCenterId { get; set; }
        
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }

       
        [ForeignKey("MedicalCenterId")]
        public virtual MedicalCenter MedicalCenter { get; set; }
    }
}
