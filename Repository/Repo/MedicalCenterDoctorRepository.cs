using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class MedicalCenterDoctorRepository : IMedicalCenterDoctor
    {
        readonly MedicalContext _medicalContext;
        public MedicalCenterDoctorRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
      
        public List<ObjectGeneral> GetMedicalCenter(int DoctorId)
        {
            var result = _medicalContext.DoctorOffice.Where(c => c.DoctorId == DoctorId).Distinct();
            var list = new List<ObjectGeneral>();
            foreach (var item in result)
            {
                var firts = _medicalContext.MedicalCenter.FirstOrDefault(x => x.Id == item.Id);
                list.Add(new ObjectGeneral { Key=firts.Id,Value=firts.Name});
            }
            return list;
        }
    }
}
