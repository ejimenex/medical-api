using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class MedicalCenter : BaseClass
    {
        public string Name   { get; set; }
        public string Address { get; set; }
        public int? CountryId { get; set; }
        public string LogoPath{ get; set; }
        public string City { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Slogan { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country CountryObj { get; set; }
    }
}
