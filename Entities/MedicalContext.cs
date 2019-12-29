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
        public DbSet<User> User { get; set; }
        public DbSet<Language> Language { get; set; }

    }
}
