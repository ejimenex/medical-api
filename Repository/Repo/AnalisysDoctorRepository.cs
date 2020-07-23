using Entities;
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Repo
{
   public class AnalysisDoctorRepository : RepositoryBase<AnalysisDoctor>
    {
        public AnalysisDoctorRepository(MedicalContext ctx) : base(ctx) {

        }
   
    }
}
