using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class PatientForm:BaseClass
    {
        public int PatientId { get; set; }
        public int QuestionId { get; set; }
        public Guid DoctorGuid { get; set; }
        public string Answer { get; set; }
        [ForeignKey("QuestionId")]
        public virtual MedicalForm MedicalForm { get; set; }
    }
}
