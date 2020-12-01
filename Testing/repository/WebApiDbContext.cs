using System;
using Microsoft.EntityFrameworkCore;
using domain;
using domain.NOAAStationAggregate;
using domain.VatsimMETARAggregate;

namespace repository
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext (DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<NOAAStation> Stations { get; set; }

        public DbSet<VatsimMETAR> VatsimMETAR { get; set; }

        // public DbSet<Student> Students { get; set; }
        // public DbSet<Enrollment> Enrollments { get; set; }
        // public DbSet<Course> Courses { get; set; }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Course>().ToTable("Course");
        //     modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
        //     modelBuilder.Entity<Student>().ToTable("Student");
        // }
    }
}