using ToDoApp.MVC.Models;

namespace ToDoApp.MVC.Repositories
{
    public interface IToDoRepo
    {
        Task Create(ToDoModel todo);
        Task Delete(int id);
        Task<List<ToDoModel>> GetAll();
        Task Update(ToDoModel todo);
    }
}