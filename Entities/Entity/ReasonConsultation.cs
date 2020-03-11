using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
    public class ReasonConsultation
    {
        [Key]
        public int Id { get; set; }
        public string Key { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
