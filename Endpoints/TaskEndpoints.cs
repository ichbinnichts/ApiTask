using Dapper.Contrib.Extensions;
using System.Reflection.Metadata.Ecma335;
using static ApiTask.Data.TaskContext;

namespace ApiTask.Endpoints
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Welcome to the Task API {DateTime.Now}");

            app.MapGet("/tasks", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tasks = con.GetAll<Task>().ToList();
                if (tasks is null) return Results.NotFound();
                return Results.Ok(tasks);
            });

            app.MapGet("/tasks/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                return con.Get<Task>(id) is Task task ? Results.Ok(task) : Results.NotFound();
            });
        }
    }
}
