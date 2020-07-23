using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class MedicalFormDto:BaseDto
    {
        public Guid DoctorGuid { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int? NoOrder { get; set; }
    }
}
