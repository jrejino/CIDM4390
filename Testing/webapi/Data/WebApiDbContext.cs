using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext (DbContextOptions<WebApiDbContext> options)
            : base(options)
        {
        }

        public DbSet<METARStation> Stations { get; set; }

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