using Lab4_04_10_2023.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab4_04_10_2023.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options)
                : base(options) { }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Learner> Learners { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Major> Majors { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>().HasData(
                new Major { MajorID = 1, MajorName = "IT" },
                new Major { MajorID = 2, MajorName = "Economics" },
                new Major { MajorID = 3, MajorName = "Mathematics" }
            );

            modelBuilder.Entity<Learner>().HasData(
                new Learner
                {
                    LearnerID = 1,
                    FirstMidName = "Carson",
                    LastName = "Alexander",
                    EnrollmentDate = DateTime.Parse("2005-09-01"),
                    MajorID = 1
                },
                new Learner
                {
                    LearnerID = 2,
                    FirstMidName = "Meredith",
                    LastName = "Alonso",
                    EnrollmentDate = DateTime.Parse("2002-09-01"),
                    MajorID = 2
                }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseID = 1050, Title = "Chemistry", Credits = 3 },
                new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3 },
                new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3 }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentID = 1, LearnerID = 1, CourseID = 1050, Grade = 5.5f },
                new Enrollment { EnrollmentID = 2, LearnerID = 1, CourseID = 4022, Grade = 7.5f },
                new Enrollment { EnrollmentID = 3, LearnerID = 2, CourseID = 1050, Grade = 3.5f },
                new Enrollment { EnrollmentID = 4, LearnerID = 2, CourseID = 4041, Grade = 7f }
            );
        }
    }
}
