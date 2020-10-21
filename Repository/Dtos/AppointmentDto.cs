using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class AppointmentDto : BaseDto
    {
        public DateTime Date { get; set; }
        [Required(ErrorMessage ="timeRequired")]
        public string Time { get; set; }
        public string Note { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int OfficeId { get; set; }
        public int AppointmentStateId { get; set; }
        public string PatientName { get; set; }
        public string OfficeName { get; set; }
        public string AppointmentStateName { get; set; }
        public int? ScheduleId
        {
            get; set;
        }
    }
}
