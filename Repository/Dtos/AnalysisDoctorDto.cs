using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class AnalysisDoctorDto:BaseDto
    {
        public Guid DoctorGuid { get; set; }
        public string Description { get; set; }
    }
}
