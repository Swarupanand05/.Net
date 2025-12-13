using Microsoft.EntityFrameworkCore;

class TaskContext: DbContext
{
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Staff> Staffs { get; set; }
    public DbSet<TaskItem> TaskItems { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=Assignment3.2;Trusted_Connection=True");
    }
}