using MiniAPI.MyRouteConstraint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddRouting(options =>
{
    options.ConstraintMap["Uint"] = typeof(MiniAPI.MyRouteConstraint.Uint);
});

var app = builder.Build();
app.MapGet("/", () => "Hello World!");
//app.MapGet("/question/{id:int}", (int id) => $"查询Id为{id}试题");
// 自定义类型Uint
app.MapGet("/question/{id:Uint}", (uint id) => $"查询Id为{id}试题");
// 支持正则表达式，如邮编号码
app.MapGet("/area/{postcode:regex(^[0-9]{{3}}-[0-9]{{4}}$)}", (string postcode) => $"邮编：{postcode}");
app.Run();