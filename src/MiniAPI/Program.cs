var builder = WebApplication.CreateBuilder();
var app = builder.Build();
app.MapGet("/", () => "Hello World!");
app.MapGet("/question/{id:int}", (int id) => $"查询Id为{id}试题");
app.Run();