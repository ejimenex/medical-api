using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class ServiceTypeRepository : IGetData<ServiceType>
    {
        readonly MedicalContext _medicalContext;
        public ServiceTypeRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public IEnumerable<ServiceType> GetData()
        {
            return _medicalContext.Set<ServiceType>().AsQueryable();
        }
    }
}
