using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;

namespace StudentCourseManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        SbContext sb = new SbContext();

        
        public IActionResult Index()
        {
            List<Student> slist = sb.Students.Include(s => s.Courses).ToList();
            return View(slist);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult AfterCreate(Student s)
        {
            sb.Students.Add(s);
            sb.SaveChanges();
            return Redirect("/Home/Index"); // Redirect to Student/Index
        }

        
        public IActionResult Edit(int id)
        {
            Student s = sb.Students.Find(id);
            return View(s);
        }

        
        [HttpPost]
        public IActionResult AfterEdit(Student s)
        {
            sb.Students.Update(s);
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }

        
        public IActionResult Delete(int id)
        {
            Student s = sb.Students.Find(id);
            return View(s);
        }

        
        [HttpPost]
        public IActionResult AfterDelete(int StudentId)
        {
            Student s = sb.Students.Find(StudentId);
            if (s != null)
            {
                sb.Students.Remove(s);
                sb.SaveChanges();
            }
            return Redirect("/Home/Index");
        }
    }
}