using ApiTask.Endpoints;
using ApiTask.Extensions;

var builder = WebApplication.CreateBuilder(args);


//The .AddPersinstence is the method that i created in the ServiceCollectionsExtension
//The ServiceCollectionsExtension is a class that is a extension of ServiceCollections
builder.AddPersistence();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

//The MapTaskEndpoints is the method that i created in TaskEndpoints
app.MapTaskEndpoints();

app.Run();
