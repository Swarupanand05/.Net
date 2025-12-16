using System.IO;
using Xunit;

namespace StudentCourseManagementSystem.Tests.Views.Course;

public class CreateViewTests
{
    [Fact]
    public void CreateView_HasCourseNameInputAndSelects()
    {
        var file = Path.Combine("..","Student CourseManagementSystem","Views","Course","Create.cshtml");
        Assert.True(File.Exists(file), $"View file not found: {file}");

        var content = File.ReadAllText(file);

        Assert.Contains("name=\"CourseName\"", content);
        Assert.Contains("<select name=\"CourseId\"", content);
        Assert.Contains("<select name=\"StudentId\"", content);
        Assert.Contains("Create Course", content);
    }
}