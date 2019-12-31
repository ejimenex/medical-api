using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
   public class UserDto:BaseDto
    {

        public string UserName { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public int? RolId { get; set; }
        public int? DoctorId { get; set; }
        public string LanguageId { get; set; }
        public bool? IsLocked { get; set; }
        public bool? IsProbatory { get; set; }
        public DateTime? ExpireDateProbatory { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
        public string RolName { get; set; }
        public virtual RoleDto Role { get; set; }
    }
}
