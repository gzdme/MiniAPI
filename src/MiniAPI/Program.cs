using MiniAPI.MyRouteConstraint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddRouting(options =>
{
    options.ConstraintMap["Uint"] = typeof(MiniAPI.MyRouteConstraint.Uint);
});

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
//app.MapGet("/question/{id:int}", (int id) => $"查询Id为{id}试题");
app.MapGet("/question/{id:Uint}", (uint id) => $"查询Id为{id}试题");
app.Run();