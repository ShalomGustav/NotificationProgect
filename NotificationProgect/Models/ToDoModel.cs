namespace NotificationProgect.Models;

public class ToDoModel
{
    public DateTime CreateDate { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool? Complited { get; set; }
    public string Contact {  get; set; }
    public ToDoType Type { get; set; }
}
