using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class MedicalSpecialityDoctor : BaseClass
    {
        public int DoctorId { get; set; }
        public int SpecialityId { get; set; }
        [ForeignKey("DoctorId")]
        public virtual Doctor Doctor { get; set; }
        [ForeignKey("SpecialityId")]
        public virtual MedicalSpeciality MedicalSpeciality { get; set; }
    }
}
