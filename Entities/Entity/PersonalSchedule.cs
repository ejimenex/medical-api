using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class PersonalSchedule:BaseClass
    {
        public int? PatientId { get; set; }
        public int EventTypeId { get; set; }
        public string Note { get; set; }
        public DateTime EventDate { get; set; }

        public bool State { get; set; }
        public Guid DoctorGuid { get; set; }
        [ForeignKey("EventTypeId")]
        public virtual EventTypes EventTypes { get; set; }

        [ForeignKey("PatientId")]
        public virtual Patient Patient { get; set; }
    }
}
