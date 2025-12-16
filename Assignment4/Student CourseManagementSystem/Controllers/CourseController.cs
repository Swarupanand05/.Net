using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentCourseManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentCourseManagementSystem.Controllers
{
    public class CourseController : Controller
    {
        SbContext sb = new SbContext();

        
        public IActionResult Index()
        {
            List<Course> clist = sb.Courses.Include(c => c.Student).ToList();
            return View(clist);
        }

        
        public void PopulateStudentsList(object selectedStudent = null)
        {
            var students = sb.Students.OrderBy(s => s.FirstName).ToList();
            ViewBag.StudentList = new SelectList(students, "StudentId", "FirstName", selectedStudent);
        }
        

        public IActionResult Create()
        {
            PopulateStudentsList();
            return View();
        }

        
        [HttpPost]
        public IActionResult AfterCreate(Course c)
        {
            sb.Courses.Add(c);
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }

        
        public IActionResult Edit(int id)
        {
            Course c = sb.Courses.Find(id);
            if (c == null)
            {
                return NotFound();
            }
          
            PopulateStudentsList(c.StudentId); 
            return View(c);
        }

        
        [HttpPost]
        public IActionResult AfterEdit(Course c)
        {
            sb.Courses.Update(c);
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }

        
        public IActionResult Delete(int id)
        {
            Course c = sb.Courses.Include(course => course.Student).FirstOrDefault(course => course.CourseId == id);
            if (c == null)
            {
                return NotFound();
            }
            return View(c);
        }

        
        [HttpPost]
        public IActionResult AfterDelete(int CourseId)
        {
            Course c = sb.Courses.Find(CourseId);
            if (c != null)
            {
                sb.Courses.Remove(c);
                sb.SaveChanges();
            }
            return Redirect("/Home/Index");
        }
    }
}