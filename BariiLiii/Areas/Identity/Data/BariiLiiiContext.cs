using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BariiLiii.Areas.Identity.Data;
using BariiLiii.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BariiLiii.Data
{
    public class BariiLiiiContext : IdentityDbContext<BariiLiiiUser>
    {
        public BariiLiiiContext(DbContextOptions<BariiLiiiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<MedicalTeam> MedicalTeams { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
    }
}
