using System.ComponentModel.DataAnnotations;

class TaskItem 
{
    [Key]
    public int TaskItemId{ get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public int StaffId { get; set; }
    public Staff Staff { get; set; }
}
