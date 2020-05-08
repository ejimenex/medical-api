using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMedical.Dtos
{
    public class DoctorDto:BaseDto
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
         public List<MedicalSpecialityDoctorDto> MedicalSpecialityDoctor { get; set; }
        public string Country { get; set; }
        public string Speciality { get; set; }
        public CountryDto CountryBorn { get; set; }
        public UserDto Users { get; set; }
        public Guid? DoctorGuid { get; set; }
    }
}
