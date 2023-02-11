using GPACalculator.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace GPACalculator.Db
{
    public class GPACalculatorDbContext : DbContext
    {
        public DbSet<StudentEntity> Students { get; set; }
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<GradeEntity> Grades { get; set; }


        public GPACalculatorDbContext(DbContextOptions<GPACalculatorDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<StudentEntity>()
                .HasMany(s => s.Courses)
                .WithMany(c => c.EnrolledStudents)
                .UsingEntity(j => j.ToTable("StudentsCourses"));


            
            
        }
    }
}
