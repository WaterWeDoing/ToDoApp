using Dapper;
using System.Data;
using System.Data.SqlClient;
using ToDoApp.MVC.Models;

namespace ToDoApp.MVC.Repositories
{
    public class TaskRepo : ITaskRepo
    {
        private readonly IConfiguration _config;

        public TaskRepo(IConfiguration config)
        {
            _config = config;
        }


        public async Task<List<TaskModel>> GetAll()
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<TaskModel> output = (await dbConnection.QueryAsync<TaskModel>("spTask_GetAll", commandType: CommandType.StoredProcedure)).ToList();
            return output;
        }

        public async Task<List<TaskModel>> GetTasks(int todoId)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<TaskModel> tasks = (await dbConnection.QueryAsync<TaskModel>("spTask_GetbyTodo", new { todoId = todoId }, commandType: CommandType.StoredProcedure)).ToList();
            return tasks;
        }

        public async Task Create(TaskModel task)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            task.TaskId = await dbConnection.QuerySingleAsync<int>("spTask_Create", new { Name = task.Name, ToDoId = task.ToDoId, Priority = task.Priority, Deadline = task.Deadline }, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(TaskModel task)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            await dbConnection.ExecuteAsync("spTask_Update", new { TaskId = task.ToDoId, Name = task.Name, Priority = task.Priority, Deadline = task.Deadline }, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(int id)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            await dbConnection.ExecuteAsync("spTask_Delete", new { TaskId = id }, commandType: CommandType.StoredProcedure);
        }


    }
}
