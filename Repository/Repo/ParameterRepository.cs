using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class ParameterRepository : IGetData<Parameter>
    {
        readonly MedicalContext _medicalContext;
        public ParameterRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<Parameter> GetData()
        {
            return _medicalContext.Parameter.Where(c=> c.Active).AsQueryable();
        }
    }
}
