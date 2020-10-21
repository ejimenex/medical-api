
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class PatientService : BaseService<Patient>
    {
        readonly IRepository<PatientForm> patient;
        readonly IRepository<MedicalForm> question;
        readonly IRepository<Doctor> doctor;
        public PatientService(IRepository<Patient> repository, IRepository<Doctor> _doctor, IRepository<PatientForm> _patient, IRepository<MedicalForm> _question) :base(repository)
        {
            patient = _patient;
            question = _question;
            doctor = _doctor;
        }
        public  override int Create(Patient entity)
        {
            if (entity.ArsId == 0) entity.ArsId = null;
            entity.PatientGuid =  Guid.NewGuid();            
            var result=  base.Create(entity);           
            var doctorGuid = doctor.GetOne(Convert.ToInt32(entity.DoctorId));
            var questions = question.FindByCondition(c => c.DoctorGuid == doctorGuid.DoctorGuid && c.IsActive).ToList();
            foreach (var item in questions)
            {
                var newPatientForm = new PatientForm();
                newPatientForm.DoctorGuid = item.DoctorGuid;
                newPatientForm.QuestionId = item.Id;
                newPatientForm.PatientId = result;
                newPatientForm.Answer = "";
                newPatientForm.MedicalForm = null;
                //patient.Create(newPatientForm);
            }
            return  result;
        }


    }
}
