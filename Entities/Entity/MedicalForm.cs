using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
   public class MedicalForm:BaseClass
    {
        public Guid DoctorGuid { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public int? NoOrder { get; set; }
    }
}
