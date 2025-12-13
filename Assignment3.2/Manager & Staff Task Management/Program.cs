using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Manager___Staff_Task_Management
{
    internal class Program
    {
        static TaskContext tc = new TaskContext();
        static void Main(string[] args)
        {
            int choice;


            do
            {
                Console.WriteLine("1. Add Manager\n2. Add Staff (assign to Manager)\n3. Add Task (assign to Staff)\n4. View all Managers, Staff & Tasks\n5. Update Task (mark as completed)\n6. Delete Task\n7. Exit\n");
                Console.WriteLine("=========================================================");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("---------------------------------------------------------");

                switch (choice)
                {
                    case 1:
                        AddManager();
                        if (true)
                            Console.WriteLine("Manager Added Sucessfully...");

                        break;
                    case 2:
                        AddStaff();
                        break;
                    case 3:
                        AddTask();

                        break;
                    case 4:
                        ViewAll();
                        break;
                    case 5:
                        UpdateTask();
                        break;
                    case 6:
                        DeleteTask();
                        break;
                    case 7:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }




            } while (choice != 0);
        }

        //Add Manager
        public static void AddManager()
        {
            Manager manager = new Manager();
            Console.WriteLine("Enter Manager Name:");
            manager.Name = Console.ReadLine();
            Console.WriteLine("Enter Manager Email:");
            manager.Email = Console.ReadLine();
            tc.Managers.Add(manager);
            tc.SaveChanges();
        }

        //Add Staff (assign to Manager)
        public static void AddStaff()
        {
            Console.WriteLine("How many staff you want to add ?");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Staff staff = new Staff();
                Console.WriteLine("Enter Staff Name:");
                staff.Name = Console.ReadLine();
                Console.WriteLine("Enter Staff Email:");
                staff.Email = Console.ReadLine();
                Console.WriteLine("Available Managers:");
                var managers = tc.Managers.ToList();
                foreach (var mgr in managers)
                {
                    Console.WriteLine($"ID: {mgr.ManagerId}, Name: {mgr.Name}");
                }
                Console.WriteLine("Enter Manager ID to assign:");
                int managerId = Convert.ToInt32(Console.ReadLine());
                staff.ManagerId = managerId;
                tc.Staffs.Add(staff);
                Console.WriteLine("Staff Added successfully...");
            }
            tc.SaveChanges();
        }

        //Add Task (assign to Staff)

        public static void AddTask()
        {
            var staffs = tc.Staffs.ToList();
            foreach (var sta in staffs)
            {
                Console.WriteLine($"ID : {sta.StaffId}, Name: {sta.Name}");
            }
            Console.WriteLine("Enter StaffId to assign a task");
            int staffId = Convert.ToInt32(Console.ReadLine());
            TaskItem taskItem = new TaskItem();
            Console.WriteLine("Enter Task Title");
            string taskTitle = Console.ReadLine();
            Console.WriteLine("Enter Discription");
            string desc = Console.ReadLine();
            Console.WriteLine("Is task completed? (true/false)");
            string taskComplete = Console.ReadLine();
            taskItem.IsCompleted = taskComplete.Trim().ToLower() == "true";
            taskItem.Title = taskTitle;
            taskItem.Description = desc;
            taskItem.StaffId = staffId;
            tc.TaskItems.Add(taskItem);
            Console.WriteLine("Task added successfully");
            tc.SaveChanges();
        }

        //View all Managers, Staff & Tasks
        public static void ViewAll()
        {
            var managers = tc.Managers.Include(m => m.staff).ThenInclude(s => s.TaskItems).ToList();
            foreach (var manager in managers)
            {
                Console.WriteLine($"Manager ID: {manager.ManagerId}, Name: {manager.Name}, Email: {manager.Email}");
                foreach (var staff in manager.staff)
                {
                    Console.WriteLine($"\tStaff ID: {staff.StaffId}, Name: {staff.Name}, Email: {staff.Email}");
                    foreach (var task in staff.TaskItems)
                    {
                        Console.WriteLine($"\t\tTask ID: {task.TaskItemId}, Title: {task.Title}, Description: {task.Description}, IsCompleted: {task.IsCompleted}");
                    }
                }
            }
        }

        //Update Task (mark as completed)
        public static void UpdateTask()
        {
            Console.WriteLine("Enter Task id");
            int taskId = Convert.ToInt32(Console.ReadLine());
            var task = tc.TaskItems.Find(taskId);
            if (task != null)
            {
                task.IsCompleted = true;
                tc.SaveChanges();
                Console.WriteLine("Task marked as completed.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }

        //Delete Task
        public static void DeleteTask()
        {
            Console.WriteLine("Enter task id to delete");
            int taskId = Convert.ToInt32(Console.ReadLine());
            var task = tc.TaskItems.Find(taskId);
            if (task != null)
            {
                tc.TaskItems.Remove(task);
                tc.SaveChanges();
                Console.WriteLine("Task Remove successfully");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        } 
    }
}
