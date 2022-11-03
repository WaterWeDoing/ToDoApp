using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.MVC.Models;
using ToDoApp.MVC.Repositories;

namespace ToDoApp.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToDoRepo _toDoRepo;
        private readonly ITaskRepo _taskRepo;

        public HomeController(ILogger<HomeController> logger, IToDoRepo toDoRepo, ITaskRepo taskRepo)
        {
            _logger = logger;
            _toDoRepo = toDoRepo;
            _taskRepo = taskRepo;
        }

        public async Task<IActionResult> Index()
        {
            List<ToDoModel> todos = await _toDoRepo.GetAll();
            Dictionary<ToDoModel, List<TaskModel>> output = new Dictionary<ToDoModel, List<TaskModel>>();

            foreach (var todo in todos)
            {
                var task = await _taskRepo.GetTasks(todo.ToDoId);
                output.Add(todo, task);
            }

            return View(output);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}