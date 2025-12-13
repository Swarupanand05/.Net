using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("Student2")]
class Student
{
    [Key]
    public int StudentId { get; set; }
    public string Name{ get; set; }
    public int Age{ get; set; }

    public List<Course> Courses { get; set; }
}