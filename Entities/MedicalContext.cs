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

        public DbSet<MedicalSpecialityDoctor> MedicalSpecialityDoctor { get; set; }
        public DbSet<Doctor> Doctor { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<MedicalSchedule> MedicalSchedule { get; set; }
        public DbSet<DoctorOffice> DoctorOffice { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<PermissionRoles> PermissionRoles { get; set; }
    }
}
