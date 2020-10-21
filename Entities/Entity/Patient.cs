using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity
{
   public class Patient : BaseClass
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Reference1 { get; set; }
        public string Reference2 { get; set; }
        public string Reference3 { get; set; }

        public string DocumentNumber { get; set; }
        public string Phone { get; set; }
        public string SSN { get; set; }
        public DateTime BornDate { get; set; }
        public int? DoctorId { get; set; }
        public int? ArsId { get; set; }
        public string Sex { get; set; }
        public Guid? PatientGuid { get; set; }
        public string FatherName { get; set; }
        public int? FatherAge { get; set; }
        public string MotherName { get; set; }
        public int? MotherAge { get; set; }
        public string PartnerName { get; set; }
        public int? PartnerAge { get; set; }
        public string civilStatus { get; set; }
        public int? ChildQty { get; set; }
        public int? Age { get; set; }
        public bool? HasPreviouslyOperated { get; set; }
        public int? HowOftenOperated { get; set; }
        public string OperationSpecification { get; set; }
        public bool? HaveThePatientHadanAccident { get; set; }
        public string AccidentSpecification { get; set; }
        public bool? HasAllergySomeMedicine { get; set; }
        public string HasAllergySomeMedicineSpecification { get; set; }
        public bool? HasAllergySomeFood { get; set; }
        public string HasAllergySomeFoodSpecification
        {
            get; set;
        }

    }
}
