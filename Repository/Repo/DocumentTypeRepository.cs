using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class DocumentTypeRepository : IGetData<DocumentType>
    {
        readonly MedicalContext _medicalContext;
        public DocumentTypeRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<DocumentType> GetData()
        {
            return _medicalContext.DocumentType.AsQueryable();
        }
    }
}
