
using Entities.Entity;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace BussinesLogic.Service
{
   public class AppointmentService : BaseService<Appointment>
    {
        readonly IRepository<MedicalSchedule> schedule;
        readonly IRepository<DoctorOffice> med;
        public AppointmentService(IRepository<Appointment> repository, IRepository<MedicalSchedule> _schedule, IRepository<DoctorOffice> _med) :base(repository)
        {
            schedule = _schedule;
            med = _med;
        }
        public override int Create(Appointment entity)
        {
            entity.AppointmentState = null;
            entity.Office = null;
            entity.Patient = null;
            var DaysOfWeek = entity.Date.DayOfWeek.ToString();
            if (entity.Date < DateTime.Now.Date)
                throw new ArgumentException("minordate");
            if (DaysOfWeek == "Saturday")
            {
       
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Saturday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Saturday != null)
                {
                    var MaxQty = Qty.MaxQuantitySaturday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantitySaturday}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Sunday")
            {
               
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Sunday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Sunday != null)
                {
                    var MaxQty = Qty.MaxQuantitySunday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantitySunday}");
                    entity.ScheduleId = Qty.Id;
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Monday")
            {
              
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Monday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Monday != null)
                {
                    var MaxQty = Qty.MaxQuantityMonday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantityMonday}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Tuesday")
            {
                
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Tuesday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Tuesday != null)
                {
                    var MaxQty = Qty.MaxQuantityTuesday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantityTuesday}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Wednesday")
            {
           
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Wednesady == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Wednesady != null)
                {
                    var MaxQty = Qty.MaxQuantityWednesady;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantityWednesady}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Thursday")
            {
             
                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Thursday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Thursday != null)
                {
                    var MaxQty = Qty.MaxQuantityThursday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantityThursday}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            if (DaysOfWeek == "Friday")
            {

                var Qty = schedule.GetOne(entity.ScheduleId);
                if (Qty.Friday == null)
                    throw new ArgumentException("cannotaddappointmentinnulldate");
                if (Qty.Friday != null)
                {
                    var MaxQty = Qty.MaxQuantityFriday;
                    var Exceded = base.FindByCondition(v => v.OfficeId == entity.OfficeId && v.ScheduleId == Qty.Id && v.Date == entity.Date);
                    if (Exceded.Count() == MaxQty)
                        throw new ArgumentException($"Las citas para este dia de la semana ya estan llenas, limite: {Qty.MaxQuantityFriday}");
                    entity.ScheduleId = Qty.Id;

                }
            }
            return base.Create(entity);
        }
        public override Appointment Update(Appointment entity)
        {
            entity.AppointmentState = null;
            entity.Office = null;
            entity.Patient = null;
            return base.Update(entity);
        }


    }
}
