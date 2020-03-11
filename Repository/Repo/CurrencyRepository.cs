using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
    public class CurrencyRepository : ICurrency
    {
        readonly MedicalContext _medicalContext;
        public CurrencyRepository(MedicalContext medicalContext)
        {
            _medicalContext = medicalContext;
        }
        public IQueryable<Currency> GetAll()
        {
            return _medicalContext.Currency.AsQueryable();
        }
    }
}
