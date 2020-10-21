using ApiMedical.Common.Filter.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Common.Filter
{
   public class ConsultationFilter:BaseFilter
    {
        public DateTime? DateTo { get; set; }
        public DateTime? DateFrom { get; set; }
        public Guid DoctorGuid { get; set; }
        public string OfficeName { get; set; }
        public string PatientName { get; set; }
        public int? PatientId { get; set; }

    }
}
