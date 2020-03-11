using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BussinesLogic.Service
{
    public class ConsultationService : BaseService<Consultation>
    {
        readonly IRepository<Appointment> app;
        public ConsultationService(IRepository<Consultation> repository, IRepository<Appointment> _app) : base(repository)
        {
            app = _app;
        }
        public override int Create(Consultation entity)
        {
            entity.Patient = null;
            entity.DoctorOffice = null;
            entity.ReasonConsultationObj = null;
            var dateNow = Convert.ToDateTime( DateTime.Now.ToString("yyyy-MM-dd"));
            var appointment = app.FindByCondition(c => c.PatientId == entity.PatientId && c.OfficeId == entity.OfficeId
            && c.Date == dateNow && c.AppointmentStateId==4)
                .FirstOrDefault();
            if (appointment != null)
            {  appointment.AppointmentStateId = 2;
                app.Update(appointment);
            }
            return base.Create(entity);
        }
        public override Consultation Update(Consultation entity)
        {
            entity.Patient = null;
            entity.DoctorOffice = null;
            entity.ReasonConsultationObj = null;
            return base.Update(entity);
        }
    }
}
