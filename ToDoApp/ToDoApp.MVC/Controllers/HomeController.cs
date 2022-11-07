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

        public async Task<IActionResult> DisplayTasks(int todoId, TaskModel task)
        { 
            Dictionary<int, TaskModel> output = new Dictionary<int, TaskModel>();
            List<TaskModel> taskList = await _taskRepo.GetAll();

            //I need to somehow get the todoId from the Index page. Page redirects to task page when clicked on the ToDo in the Index, but needs to pass the Id to the parameter. Viewbag or View model????
            foreach (var t in taskList)
            {
                if (task.ToDoId == todoId)
                {
                    output.Add(todoId, t);
                    task.ToDoId = t.ToDoId;
                }
            }
            
            return View(output);
        }

        public IActionResult AddTasks(int todoId, TaskModel task)
        {
            task.ToDoId = todoId;
            _taskRepo.Create(task);
            return View(task);
        }

        public IActionResult AddToDo(ToDoModel todo)
        {
            _toDoRepo.Create(todo);
            return View(todo);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}