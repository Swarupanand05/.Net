using System.ComponentModel.DataAnnotations;

class Manager
{
    [Key]
    public int ManagerId { get; set; }
    public string Name { get; set; }
    public string Email{ get; set; }

    public List<Staff> staff {  get; set; }

}
