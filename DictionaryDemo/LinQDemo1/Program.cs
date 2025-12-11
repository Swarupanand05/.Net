using System;
using System.Collections.Generic;
using System.Linq;
namespace LinQDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                 new Employee(){empId=1, name= "Alice", department="IT", salary=50000},
                 new Employee(){empId=2, name= "Bob", department="Accounting", salary=60000},
                 new Employee(){empId=3, name= "Charlie", department="IT", salary=55000},
                 new Employee(){empId=4, name= "David", department="Marketing", salary=70000},
                 new Employee(){empId=5, name= "Eve", department="Accounting", salary=65000},
            };
            //Print names of employees from 'IT' department.
            var itEmployees = from emp in employees
                              where emp.department == "IT"
                              select emp;
            Console.WriteLine("Employees from IT Department:");
            foreach (var emp in itEmployees)
            {
                emp.Display();

            }
            //Print names of employees highest salary.
            var highestSalaryEmployee = (from emp in employees
                                         orderby emp.salary descending
                                         select emp).FirstOrDefault();
            Console.WriteLine("\nEmployee with Highest Salary:");
            if (highestSalaryEmployee != null)
            {
                highestSalaryEmployee.Display();
            }
            else
            {
                Console.WriteLine("No employees available.");
            }

            //Group employees by department.
            var groupedByDepartment = from emp in employees
                                      group emp by emp.department;
            Console.WriteLine("\nEmployees Grouped by Department:");
            foreach (var group in groupedByDepartment)
            {
                Console.WriteLine("Department: " + group.Key);
                foreach (var emp in group)
                {
                    emp.Display();
                }


            }
        }
    }
}

class Employee
{
    public int empId { get; set; }
    public string name { get; set; }
    public string department { get; set; }
    public double salary { get; set; }

    public void Display()
    {
        Console.WriteLine("Emp ID: " + empId + ", Name: " + name + ", Department: " + department + ", Salary: " + salary);
    }
}
