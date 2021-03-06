﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class Users : BaseClass
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

        [ForeignKey("RolId")]
        public virtual Role Role { get; set; }
    }
}
