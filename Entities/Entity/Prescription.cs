using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class Prescription:BaseClass
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int OfficeId { get; set; }
        public string Medicine { get; set; }
        public string MedicineUse { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Time { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
