using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class ConsultationDto:BaseDto
    {
        public int PatientId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please select a Office / Por favor seleccione un consultorio")]
        public int OfficeId { get; set; }
        public int? AppointmentId { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Please select a reason to visit / Por favor seleccione un motivo de consulta")]
        public int ReasonVisitId { get; set; }
        public int DoctorId { get; set; }
        public string ReasonConsultation { get; set; }
        public string Diagnosis { get; set; }
        [Required(ErrorMessage ="Please enter an Medical Indication / Por favor digite una indicación medica")]
        public string MedicalIndication { get; set; }
        public string MedicalObservation1 { get; set; }
        public string MedicalObservation2 { get; set; }
        public DateTime NextDateVisit { get; set; }
        public string OfficeName { get; set; }
        public string PatientName { get; set; }
        public string ReasonDescription { get; set; }
        public bool? HaveTakenMedications { get; set; }
        public string HaveTakenMedicationsDetails { get; set; }
        public bool? HaveBeenThatProblemBefore { get; set; }
        public string HaveBeenThatProblemBeforeDetail { get; set; }
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
    }
}
