using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities.Entity
{
    public class Doctor : BaseClass
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Mail { get; set; }
        public string Exequatur { get; set; }
        public string DocumentId { get; set; }
        public DateTime BornDate { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Treament { get; set; }
        public string PhotoPath { get; set; }
        public string TitlePath { get; set; }
        public string Phone1 { get; set; }
        public string CellPhone { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int Nationality { get; set; }
        //[NotMapped]
        public virtual List<MedicalSpecialityDoctor> MedicalSpecialityDoctor { get;set;}
        [NotMapped]
        public virtual Users Users { get; set; }
        [NotMapped]
        [ForeignKey("Nationality")]
        public virtual Country CountryBorn { get; set; }
       // [NotMapped]
        [ForeignKey("CountryId")]
        public virtual Country CountryWork { get; set; }
        public Guid? DoctorGuid { get; set; }
    }
}
