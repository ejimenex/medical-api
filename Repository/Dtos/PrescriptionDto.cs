using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Repository.Dtos
{
    public class PrescriptionDto:BaseDto
    {
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int OfficeId { get; set; }
        [Required(ErrorMessage ="Medicine field is required / Campo medicina es requerido")]
        public string Medicine { get; set; }
        public string MedicineUse { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Time { get; set; }
       public string  PatientName { get; set; }
    }
}
