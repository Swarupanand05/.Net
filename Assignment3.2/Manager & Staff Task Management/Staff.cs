using System.ComponentModel.DataAnnotations;

class Staff
{
    [Key]
    public int StaffId{ get; set; }
    public string Name { get; set; }
    public string Email{ get; set; }

    public int ManagerId { get; set; }

    public Manager Manager { get; set; }
    public List<TaskItem> TaskItems { get; set; }
}
