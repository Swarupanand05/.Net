using System;
using System.Collections.Generic;

namespace JoinedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { id = 1, name = "Anil" },
                new Student { id = 2, name = "Bina" },
                new Student { id = 3, name = "Chetan" }
            };
            
            List<Marks> marks = new List<Marks> {
                new Marks { studentId = 1, subject = "Math", score = 78 },
                new Marks { studentId = 2, subject = "Science", score = 75 },
                new Marks { studentId = 1, subject = "Math", score = 90 },
                new Marks { studentId = 3, subject = "History", score = 85 },
                new Marks { studentId = 2, subject = "bio", score = 100 }


            };

            foreach (var s in students)
                s.Display();
            Console.WriteLine();
            Console.WriteLine();
            foreach (var m in marks)
                m.Display();
            Console.WriteLine();
            Console.WriteLine();


            var joined = from s in students
                         join m in marks on s.id equals m.studentId
                         select new { s.name, m.subject, m.score };


            Console.WriteLine("Student Name - Subject - Score:");
            foreach (var item in joined)
                Console.WriteLine($"{item.name} - {item.subject} - {item.score}");

        }
    }
}

class Student
{
    public int id { get; set; }
    public string name { get; set; }

    public void Display()
    {
        Console.WriteLine("ID: " + id + ", Name: " + name);
    }
}

class Marks
{
    public int studentId { get; set; }
    public string subject { get; set; }
    public int score { get; set; }

    public void Display()
    {
        Console.WriteLine("Student ID: " + studentId + ", Subject: " + subject + ", Score: " + score);
    }
}
