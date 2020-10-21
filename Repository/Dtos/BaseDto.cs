using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Dtos
{
   public class BaseDto
    {
        public int Id { get; set; }
        public int? CreateBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Version { get; set; }
        public bool IsActive { get; set; }
    }
}
