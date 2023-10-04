using System.ComponentModel.DataAnnotations.Schema;

namespace Lab4_04_10_2023.Models
{
    public class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
