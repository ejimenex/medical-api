using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class PatientFormDto:BaseDto
    {
        public int PatientId { get; set; }
        public int QuestionId { get; set; }
        public Guid DoctorGuid { get; set; }
        public string Answer { get; set; }
        public string QuestionName { get; set; }

        public string Type { get; set; }
    }
}
