using ApiMedical.Common.Filter.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiMedical.Common.Filter
{
    public class MedicalProcessFilter : BaseFilter
    {
        public string PatientName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? ToDate { get; set; }
        public int DoctorId{get;set;}

    }
}
