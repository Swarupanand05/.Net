using Microsoft.EntityFrameworkCore;

namespace NavigationProperty
{

    internal class Program
    {
        static StudentContext sb = new StudentContext();

        static void Main(string[] args)
        {
            
            int choice;
            do
            {
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("1.Display Students\n2.Add Students\n3.Find Student\n4.Update Student\n5.Delete Student\n6.EXIT");
                Console.WriteLine("============================================================");
                Console.WriteLine("============================================================");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        List<Student> students = GetAllStudent();
                        foreach (var student in students)
                        {
                            Console.WriteLine($"StudentId:{student.StudentId}, Name:{student.Name}");
                            if (student.Courses != null && student.Courses.Count > 0)
                            {
                                Console.WriteLine("Courses:");
                                foreach (var course in student.Courses)
                                {
                                    Console.WriteLine($"\tCourseId:{course.CourseId}, CourseName:{course.CourseName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\tNo courses enrolled.");
                            }
                        }
                        break;
                    case 2:
                        int result = AddStudentWithCourses();
                        if (result > 0)
                        {
                            Console.WriteLine("Student added successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add student.");
                        }




                        break;
                    case 3:
                        Console.WriteLine("Enter Student ID to find:");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Student studentFound = FindStudentWithCourses(studentId);
                        if (studentFound != null)
                        {
                            Console.WriteLine($"StudentId:{studentFound.StudentId}, Name:{studentFound.Name}");
                            if (studentFound.Courses != null && studentFound.Courses.Count > 0)
                            {
                                Console.WriteLine("Courses:");
                                foreach (var course in studentFound.Courses)
                                {
                                    Console.WriteLine($"\tCourseId:{course.CourseId}, CourseName:{course.CourseName}");
                                }
                            }
                            else
                            {
                                Console.WriteLine("\tNo courses enrolled.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Student ID to update:");
                        int updateStudentId = Convert.ToInt32(Console.ReadLine());
                        int updateResult = UpdateStudentWithCourses(updateStudentId);
                        if (updateResult > 0)
                        {
                            Console.WriteLine("Student updated successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to update student.");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Student ID to delete:");
                        int deleteStudentId = Convert.ToInt32(Console.ReadLine());
                        int deleteResult = DeleteStudentWithCourses(deleteStudentId);
                        if (deleteResult > 0)
                        {
                            Console.WriteLine("Student deleted successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Failed to delete student.");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong Choice Enter Another Choice");
                        break;


                }
            } while (choice != 0);
        }

        //Get all students along with their courses
        public static List<Student> GetAllStudent()
        {
            List<Student> students = sb.Students.Include(s => s.Courses).ToList();
            return students;
        }

        //Add new student with courses from user
        public static int AddStudentWithCourses()
        {   
            Console.WriteLine("Enter Student Name:");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Student Age:");
            int age = Convert.ToInt32(Console.ReadLine());
            Student s = new Student
            {
                Name = name,
                Age = age,
                Courses = new List<Course>()
            };
            Console.WriteLine("Enter number of courses to add:");
            int courseCount = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < courseCount; i++)
            {
                Console.WriteLine($"Enter name of course {i + 1}:");
                string courseName = Console.ReadLine();
                s.Courses.Add(new Course { CourseName = courseName });
            }
            sb.Students.Add(s);
            return sb.SaveChanges();
        }


        //Find student by ID along with their courses  
        public static Student FindStudentWithCourses(int StudentId)
        {
            Student s = sb.Students.Include(st => st.Courses).FirstOrDefault(st => st.StudentId == StudentId);
            return s;
        }

        //Update student details along with their courses from user
        public static int UpdateStudentWithCourses(int StudentId)
        {
            Student s = sb.Students.Include(st => st.Courses).FirstOrDefault(st => st.StudentId == StudentId);
            if (s != null)
            {
                Console.WriteLine("Enter new name:");
                s.Name = Console.ReadLine();
                Console.WriteLine("Enter new age:");
                s.Age = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Do you want to add a new course? (yes/no)");
                string addCourseResponse = Console.ReadLine();
                if (addCourseResponse.ToLower() == "yes")
                {
                    Console.WriteLine("Enter course name:");
                    string courseName = Console.ReadLine();
                    s.Courses.Add(new Course { CourseName = courseName });
                }
                return sb.SaveChanges();
            }
            return 0;
        }

        //Detele student by ID with their courses
        public static int DeleteStudentWithCourses(int StudentId)
        {
            Student s = sb.Students.Include(st => st.Courses).FirstOrDefault(st => st.StudentId == StudentId);
            if (s != null)
            {
                sb.Students.Remove(s);
                return sb.SaveChanges();
            }
            return 0;
        }

        
    }
}   



