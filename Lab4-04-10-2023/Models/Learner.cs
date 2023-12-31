﻿namespace Lab4_04_10_2023.Models
{
    public class Learner
    { 
        public Learner()
        {
            Enrollments = new HashSet<Enrollment>();
        }
        public int LearnerID { get; set; }
        public string? LastName { get; set; }
        public string? FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public int MajorID { get; set; }
        public virtual Major? Major { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }
    }
}
