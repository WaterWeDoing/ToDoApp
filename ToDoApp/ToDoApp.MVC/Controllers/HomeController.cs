using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDoApp.MVC.Models;
using ToDoApp.MVC.Models.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> DisplayTasks(int id)
        {
            ToDoModel todo = await _toDoRepo.Get(id);
            List<TaskModel> tasks = await _taskRepo.GetTasks(todo.ToDoId);

            return View(new TodoTaskViewModel
            {
                ToDo = todo,
                Tasks = tasks
            });
        }

        public async Task<IActionResult> UpdateTask(TaskModel task)
        {
            
            await _taskRepo.Update(task);
            
            return RedirectToAction(nameof(DisplayTasks), new { id = task.ToDoId });
        }


        [HttpPost]
        public async Task<IActionResult> AddTasks(TaskModel task)
        {
            if (ModelState.IsValid)
            {
                await _taskRepo.Create(task);
            }
            else
            {
                TempData["error"] = true;
            }
            return RedirectToAction(nameof(DisplayTasks), new { id = task.ToDoId});
        }

        public IActionResult DisplayTasksPartial(int id)
        {
            return PartialView("_AddTasks", new TaskModel { ToDoId = id });
        }

        

        [HttpPost]
        public async Task<IActionResult> AddToDo(ToDoModel todo)
        {
            if (ModelState.IsValid)
            {
                await _toDoRepo.Create(todo);
                return RedirectToAction(nameof(DisplayTasks), new { id = todo.ToDoId});
            }
            return View(todo);
        }

        [HttpGet]
        public IActionResult AddToDo()
        {
            return View();
        }

       

        
        public async Task<IActionResult> DeleteTask(int id)
        {
            TaskModel task = await _taskRepo.Get(id);
            await _taskRepo.Delete(task.TaskId);
            return RedirectToAction(nameof(DisplayTasks), new {id =  task.ToDoId});
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}