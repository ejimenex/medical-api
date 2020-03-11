using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Interface
{
   public interface IMedicalCenterDoctor
    {
        List<ObjectGeneral> GetMedicalCenter(int DoctorId);
    }
}
