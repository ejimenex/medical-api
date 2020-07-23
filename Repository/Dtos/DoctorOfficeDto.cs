using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class DoctorOfficeDto:BaseDto
    {
        public string Name { get; set; }
        public string Specification { get; set; }
        public string UrlMapsAddress { get; set; }
        public int DoctorId { get; set; }
        public int MedicalCenterId { get; set; }
        public string DoctorName { get; set; }
        public string MedicalCenterName { get; set; }
    }
}
