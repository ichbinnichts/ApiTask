using Dapper.Contrib.Extensions;
using System.Reflection.Metadata.Ecma335;
using static ApiTask.Data.TaskContext;

namespace ApiTask.Endpoints
{
    public static class TaskEndpoints
    {
        public static void MapTaskEndpoints(this WebApplication app)
        {

            //Home
            app.MapGet("/", () => $"Welcome to the Task API {DateTime.Now}");


            //Get tasks
            app.MapGet("/tasks", async (GetConnection connectionGetter) =>
            {
                using var con = await connectionGetter();
                var tasks = con.GetAll<Task>().ToList();
                if (tasks is null) return Results.NotFound();
                return Results.Ok(tasks);
            });

            //Get task by id
            app.MapGet("/tasks/{id}", async (GetConnection connectionGetter, int id) =>
            {
                using var con = await connectionGetter();
                return con.Get<Task>(id) is Task task ? Results.Ok(task) : Results.NotFound();
            });

            //Post task
            app.MapPost("/tasks", async (GetConnection connectionGetter, Task task) =>
            {
                using var con = await connectionGetter();
                var id = con.Insert(task);
                return Results.Created($"/tasks/{id}", task);
            });
            //Put task
            app.MapPut("/tasks", async (GetConnection connectionGetter, Task task) =>
            {
                using var con = await connectionGetter();
                var id = con.Update(task);
                return Results.Ok(task);
            });


        }
    }
}
