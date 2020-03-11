using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repo
{
   public class ReasonConsultationRepository : IReasonRepository
    {
        readonly MedicalContext _medicalContext;
        public ReasonConsultationRepository(MedicalContext ctx) {
            _medicalContext = ctx;
        }
        public List<ReasonConsultation> Reasons() {
            var result= _medicalContext.ReasonConsultation.Where(c => c.IsActive).ToList();
            return result;
        }

    }
}
