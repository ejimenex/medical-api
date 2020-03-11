using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
   public class Menu
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public bool? display { get; set; }
        public int? Order { get; set; }
        public virtual List<Children> children { get; set; }
        
    }
    public class Children
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string icon { get; set; }
        public bool? display { get; set; }
        public int? Order { get; set; }
        public int? MenuId { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }

    }
}
