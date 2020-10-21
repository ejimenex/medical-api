using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
    public class ServiceType
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
