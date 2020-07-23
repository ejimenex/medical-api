using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
   public class MedicalFile:BaseClass
    {
        public string FileName { get; set; }
        public string FullPath { get; set; }
        public string FileExtension { get; set; }
        public Guid DoctorGuid { get; set; }        
        public Guid? PatientGuid { get; set; }
        public int? ConsultationId { get; set; }
        public int? TypeId { get; set; }
    }
}
