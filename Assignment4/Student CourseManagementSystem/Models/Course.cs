using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagementSystem.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
         public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
