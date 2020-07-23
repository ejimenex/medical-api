using ApiMedical.Common.Filter.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Common.Filter
{
   public class ConsultationFilter:BaseFilter
    {
        public DateTime? dateto { get; set; }
        public DateTime? datefrom { get; set; }
        public int DoctorId { get; set; }
        public string OfficeName { get; set; }
        public string PatientName { get; set; }
        public int? PatientId { get; set; }

    }
}
