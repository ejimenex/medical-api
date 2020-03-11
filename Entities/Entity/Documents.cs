using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Entity
{
    public class Documents : BaseClass
    {
        public string Name { get; set; }
        public string UrlDocument { get; set; }
        public Guid? DoctorGuid { get; set; }
        public Guid? PatientGuid { get; set; }
        public int  DocumentTypeId {get;set;}
        public virtual DocumentType DocumentType { get; set; }
    }
}
