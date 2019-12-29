using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class LanguageRepository:ILanguage
    {
        readonly MedicalContext _medicalContext;
        public LanguageRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<Language> Get() {
            return _medicalContext.Language.AsQueryable();
        }
   
    }
}
