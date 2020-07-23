using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class PatientDto : BaseDto
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
