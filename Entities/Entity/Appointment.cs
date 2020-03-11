using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class Appointment:BaseClass
    {
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public string Note { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int OfficeId { get; set; }
        public int ScheduleId { get; set; }
        public int? AppointmentStateId{ get; set; }
        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
        [ForeignKey("OfficeId")]
        public virtual DoctorOffice Office { get; set; }
        [ForeignKey("AppointmentStateId")]
        public virtual AppointmentState AppointmentState { get; set; }
    }
}
