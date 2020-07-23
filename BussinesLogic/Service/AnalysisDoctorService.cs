
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
namespace BussinesLogic.Service
{
   public class AnalysisDoctorService : BaseService<AnalysisDoctor>
    {
        
        public AnalysisDoctorService(IRepository<AnalysisDoctor> repository):base(repository)
        {
        
        }
        public override int Create(AnalysisDoctor entity)
        {
            var exist = _repository.Exist(x => x.Description == entity.Description && x.IsActive);
            if (exist) throw new ArgumentException("l.exist");
            return base.Create(entity);
        }


    }
}
