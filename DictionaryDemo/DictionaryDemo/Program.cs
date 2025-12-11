using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> students = new Dictionary<int, string>();
            students.Add(1, "Alice");
            students.Add(2, "Bob");
            students.Add(3, "Charlie");

            foreach (KeyValuePair<int, string> student in students)
            {
                Console.WriteLine("Roll No: " + student.Key + ", Name: " + student.Value);
            }
            //Search and display student name if roll number is provided.
            Console.WriteLine("\nEnter roll number to search:");
            int rollno = Convert.ToInt32(Console.ReadLine());   
            if (students.ContainsKey(rollno))
            {
                Console.WriteLine("Student Found: " + students[rollno]);
            }
            else
            {
                Console.WriteLine("Student with this roll number does not exist.");
            }

            // Print all entries in alphabetical order of names.
            Console.WriteLine("All entries in alphabetical order of names");
            foreach (var student in students.OrderBy(s => s.Value))
            {
                Console.WriteLine("Roll No: " + student.Key + ", Name: " + student.Value);
            }



        }
    }
}


class Student
{
    public int rollNo { get; set; }
    public string name { get; set; }

    public void Display()
    {
        Console.WriteLine("Roll No: " + rollNo + ", Name: " + name);
    }
}