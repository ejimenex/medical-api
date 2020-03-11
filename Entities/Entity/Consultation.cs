using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class Consultation:BaseClass
    {
        public int PatientId { get; set; }
        public int OfficeId { get; set; }
        public int? AppointmentId { get; set; }
        public int ReasonVisitId { get; set; }
        public int DoctorId { get; set; }
        public string ReasonConsultation { get; set; }
        public string Diagnosis { get; set; }
        public string MedicalIndication { get; set; }
        public string MedicalObservation1 { get; set; }
        public string MedicalObservation2 { get; set; }
        
        public bool? HaveTakenMedications { get; set; }
        public string HaveTakenMedicationsDetails {get;set;}
          public bool? HaveBeenThatProblemBefore { get; set; }
        public string HaveBeenThatProblemBeforeDetail {get;set;}
          public string WendDidItStart { get; set; }
        public bool? RecentlyIngestedAlcohol { get; set; }
        public bool? Vomit { get; set; }
        public bool? Fainting { get; set; }
        public bool? Diarrhea { get; set; }
        public bool? Sickness { get; set; }
        public bool? Fever { get; set; }
        public bool? LackAppetite { get; set; }
        public bool? Other { get; set; }
        public string OtherDetail { get; set; }
        public DateTime NextDateVisit { get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("OfficeId")]
        public virtual DoctorOffice DoctorOffice { get; set; }
        [ForeignKey("ReasonVisitId")]
        public virtual ReasonConsultation ReasonConsultationObj { get; set; }

    }
}
