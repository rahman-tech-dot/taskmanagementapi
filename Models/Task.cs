using System.ComponentModel.DataAnnotations;

public class Task
{
    public int Id { get; set; }
    [Required] public string Title { get; set; }
    public string Description { get; set; }
    public int AssignedUserId { get; set; }
    public DateTime CreatedDate { get; internal set; }
}