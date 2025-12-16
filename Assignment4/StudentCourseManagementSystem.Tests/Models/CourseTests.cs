using Xunit;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Tests.Models
{
    public class CourseTests
    {
        [Fact]
        public void Course_Defaults_Are_Correct()
        {
            var course = new Course();

            Assert.Equal(0, course.CourseId);
            Assert.Null(course.CourseName);
            Assert.Equal(0, course.StudentId);
            Assert.Null(course.Student);
        }

        [Fact]
        public void Can_Set_Course_Properties()
        {
            var student = new Student { StudentId = 5, FirstName = "John", LastName = "Doe" };
            var course = new Course
            {
                CourseId = 10,
                CourseName = "Algebra",
                StudentId = student.StudentId,
                Student = student
            };

            Assert.Equal(10, course.CourseId);
            Assert.Equal("Algebra", course.CourseName);
            Assert.Equal(5, course.StudentId);
            Assert.Same(student, course.Student);
        }
    }
}