using ToDoApp.MVC.Models;

namespace ToDoApp.MVC.Repositories
{
    public interface ITaskRepo
    {
        Task Create(TaskModel task);
        Task Delete(int id);
        Task<List<TaskModel>> GetAll();
        Task<List<TaskModel>> GetTasks(int todoId);
        Task Update(TaskModel task);
    }
}