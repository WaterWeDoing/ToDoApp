namespace ToDoApp.MVC.Models.ViewModels
{
    public class TodoTaskViewModel
    {
        public ToDoModel ToDo { get; set; }
        public List<TaskModel> Tasks { get; set; }

    }
}
