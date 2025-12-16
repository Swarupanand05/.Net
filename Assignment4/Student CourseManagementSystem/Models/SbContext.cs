using Microsoft.EntityFrameworkCore;

namespace StudentCourseManagementSystem.Models
{
    public class SbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(LocalDB)\\MSSQLLocalDB;Database=StudentDB;Trusted_Connection=True;Encrypt=False;");
        }

    }
}
