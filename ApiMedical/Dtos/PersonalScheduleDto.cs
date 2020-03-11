using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class PersonalScheduleDto:BaseDto
    {
        public int? PatientId { get; set; }
        public int EventTypeId { get; set; }
        public string Note { get; set; }
        public DateTime EventDate { get; set; }
        public bool State { get; set; }
        public Guid DoctorGuid { get; set; }
        public string EventName { get; set; }
        public string PatientName { get; set; }
    }
}
