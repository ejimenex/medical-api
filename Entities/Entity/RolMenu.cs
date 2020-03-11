using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class RolMenu
    {
        [Key]
        public int Id { get; set; }
        public int? RolId { get; set; }
        public string Menu { get; set; }
        public bool? Permitted { get; set; }
    }
}
