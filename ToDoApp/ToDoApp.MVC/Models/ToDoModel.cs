namespace ToDoApp.MVC.Models
{
    public class ToDoModel
    {
        public int ToDoId { get; set; }
        public string Name { get; set; } = default!;
        public int Priority { get; set; } = 3;
        public DateTime? Deadline { get; set; }
        public DateTime DateCreated { get; set; }

    }
}
