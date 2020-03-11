using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class Patient : BaseClass
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }

        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public DateTime BornDate { get; set; }
        public int? DoctorId { get; set; }
        public int? ArsId { get; set; }
        public string Sex { get; set; }
        public Guid? PatientGuid { get; set; }
    }
}
