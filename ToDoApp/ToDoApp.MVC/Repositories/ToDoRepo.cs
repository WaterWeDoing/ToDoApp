using Dapper;
using System.Data;
using System.Data.SqlClient;
using ToDoApp.MVC.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoApp.MVC.Repositories
{
    public class ToDoRepo : IToDoRepo
    {
        private readonly IConfiguration _config;

        public ToDoRepo(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<ToDoModel>> GetAll()
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            List<ToDoModel> output = (await dbConnection.QueryAsync<ToDoModel>("spToDo_GetAll", commandType: CommandType.StoredProcedure)).ToList();
            return output;
        }

        public async Task<ToDoModel> Get(int id)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            ToDoModel toDo = await dbConnection.QuerySingleOrDefaultAsync<ToDoModel>("spToDo_Get", new { ToDoId = id }, commandType: CommandType.StoredProcedure);
            return toDo;
        }

        public async Task Create(ToDoModel todo)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            todo.ToDoId = await dbConnection.QuerySingleAsync<int>("spToDo_Create", new { Name = todo.Name, Priority = todo.Priority, Deadline = todo.Deadline }, commandType: CommandType.StoredProcedure);
        }

        public async Task Update(ToDoModel todo)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            await dbConnection.ExecuteAsync("spToDo_Update", new { ToDoId = todo.ToDoId, Name = todo.Name, Priority = todo.Priority, Deadline = todo.Deadline }, commandType: CommandType.StoredProcedure);
        }

        public async Task Delete(int id)
        {
            string connString = _config.GetConnectionString("ToDoDb");
            using IDbConnection dbConnection = new SqlConnection(connString);

            await dbConnection.ExecuteAsync("spToDo_Delete", new { ToDoId = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
