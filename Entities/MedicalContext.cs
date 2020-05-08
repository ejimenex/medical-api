using Entities.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
   public class MedicalContext:DbContext
    {
        public MedicalContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Country> Country { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<HealthManager> HealthManager { get; set; }
        public DbSet<MedicalCenter> MedicalCenter { get; set; }
        public DbSet<MedicalSpeciality> MedicalSpeciality { get; set; }
        public DbSet<PersonalSchedule> PersonalSchedule { get; set; }
        public DbSet<MedicalSpecialityDoctor> MedicalSpecialityDoctor { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<MedicalSchedule> MedicalSchedule { get; set; }
        public DbSet<DoctorOffice> DoctorOffice { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionRoles> PermissionRoles { get; set; }
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentState> AppointmentState { get; set; }
        public DbSet<ReasonConsultation> ReasonConsultation { get; set; }
        public DbSet<Consultation> Consultation { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Prescription> Prescription { get; set; }
        public DbSet<RolMenu> RolMenu { get; set; }
        public DbSet<EventTypes> EventTypes { get; set; }
        public DbSet<MedicalServices> MedicalServices { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<MedicalForm> MedicalForm { get; set; }
        public DbSet<PatientForm> PatientForm { get; set; }
        public DbSet<Parameter> Parameter { get; set; }
        public DbSet<DocumentType> DocumentType { get; set; }
        public DbSet<Documents> Documents { get; set; }
        public DbSet<InvoiceDiscountReason> InvoiceDiscountReason { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetail { get; set; }
    }
}
