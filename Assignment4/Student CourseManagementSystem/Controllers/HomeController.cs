using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;

public class HomeController : Controller
{
    SbContext sb = new SbContext();

    
    public IActionResult Index()
    {
        List<Student> stud = sb.Students.Include(s => s.Courses).ToList();

        return View(stud);
    }
}