using System.ComponentModel.DataAnnotations;

namespace ToDoApp.MVC.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public int ToDoId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = default!;
        
        [Range(1,3)]
        public int Priority { get; set; } = 3;
        public DateTime? Deadline { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
