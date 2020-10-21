using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Entity.View
{
   public class VwInvoicesNoFact
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public int? PatientId { get; set; }
        public string DocumentNumber { get; set; }
        public string PatientName { get; set; }
        public string ServiceName { get; set; }
        public decimal? Amount { get; set; }
        public string Type { get; set; }
        public int? StatusC { get; set; }
        public string StatusDescription { get; set; }
    }
}
