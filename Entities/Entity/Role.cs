using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class Role
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string RolName { get; set; }
    }
}
