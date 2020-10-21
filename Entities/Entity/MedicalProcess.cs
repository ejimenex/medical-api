using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class MedicalProcess:BaseClass
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ProcessDate { get; set; }
        public int ProcessStatus { get; set; }
        public string Observation { get; set; }
        public int ServiceType { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("ServiceId")]
        public virtual MedicalServices Service { get; set; }
        [ForeignKey("ProcessStatus")]
        public virtual MedicalProcessStatus MedicalProcessStatus { get; set; }
        [ForeignKey("ServiceType")]
        public virtual ServiceType ServiceTypeObj { get; set; }
        public string Place { get; set; }
        [ForeignKey("OfficeId")]
        public virtual DoctorOffice DoctorOffice { get; set; }
        public int OfficeId { get; set; }
    }
}
