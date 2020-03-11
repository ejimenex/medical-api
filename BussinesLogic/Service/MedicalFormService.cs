
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class MedicalFormService : BaseService<MedicalForm>
    {
        readonly IRepository<PatientForm> form;
        readonly IRepository<Doctor> doctor;
        readonly IRepository<Patient> patient;
        public MedicalFormService(IRepository<MedicalForm> repository, IRepository<PatientForm> _form, IRepository<Doctor> _doctor, IRepository<Patient> _patient) :base(repository)
        {
            form = _form;
            doctor = _doctor;
            patient = _patient;
        }
        public override int Create(MedicalForm entity)
        {
            var exist = _repository.Exist(x => x.Question == entity.Question && x.IsActive && x.DoctorGuid==entity.DoctorGuid);
            if (exist) throw new ArgumentException("l.exist");
            var doct = doctor.FindByCondition(c=> c.DoctorGuid==entity.DoctorGuid).FirstOrDefault();
            var patients = patient.FindAll().Where(c => c.DoctorId == doct.Id).ToList();
            
          var result=base.Create(entity);
            foreach (var item in patients)
            {
                var obj = new PatientForm();
                obj.DoctorGuid = entity.DoctorGuid;
                obj.PatientId = item.Id;
                obj.Answer = "";
                obj.QuestionId =result;
                form.Create(obj);
            }
            return result;
        }


    }
}