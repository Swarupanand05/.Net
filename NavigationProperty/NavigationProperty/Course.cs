using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Course2")]
class Course
{
    [Key]
    public int CourseId { get; set; }
    public string   CourseName { get; set; }

    public int StudentId { get; set; }

    public Student Student { get; set; }

}
