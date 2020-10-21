using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dtos
{
   public class MedicalProcessDto:BaseDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int ServiceId { get; set; }
        public DateTime ProcessDate { get; set; }
        public int ProcessStatus { get; set; }
        public string Observation { get; set; }
        public int ServiceType { get; set; }
        public  PatientDto Patient { get; set; }
        public string MedicalServicesName  { get; set; }
        public string MedicalProcessStatusName  { get; set; }
        public string ServiceTypeName { get; set; }
        public string Place { get; set; }
        public string OfficeName { get; set; }
        public int OfficeId { get; set; }
    }
}
