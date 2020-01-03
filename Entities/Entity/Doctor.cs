using System;
using System.Collections.Generic;
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
        public char Sex { get; set; }
        public string Treament {get;set;}
        public string PhotoPath { get; set; }
        public string TitlePath { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string City { get; set; }
        public int CountryId { get; set; }
        public int Nationality { get; set; }
    }
}
