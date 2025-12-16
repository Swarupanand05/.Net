using System.ComponentModel.DataAnnotations;

namespace StudentCourseManagementSystem.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public List<Course> Courses { get; set; } 

    }
}
