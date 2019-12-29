using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class User:BaseClass
    {
    
        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? RolId { get; set; }
        public int? DoctorId { get; set; }
        public string LanguageId { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsProbatory{ get; set; }
        public DateTime? ExpireDateProbatory { get; set; }
    }
}
