using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class BaseClass
    {
        [Key]
        public int Id { get; set; }
        public int? CreateBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }



    }
}
