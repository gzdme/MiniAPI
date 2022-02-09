using Microsoft.AspNetCore.Mvc;
using MiniAPI.Domain;
using MiniAPI.MyRouteConstraint;

var builder = WebApplication.CreateBuilder();
builder.Services.AddRouting(options =>
{
    options.ConstraintMap["Uint"] = typeof(MiniAPI.MyRouteConstraint.Uint);
});

var app = builder.Build();

// 基本映射
app.MapGet("/", () => "Hello World!");
//app.MapGet("/question/{id:int}", (int id) => $"查询Id为{id}试题");
// 自定义类型Uint
app.MapGet("/question/{id:Uint}", (uint id) => $"查询Id为{id}试题");
// 支持正则表达式，如邮编号码
app.MapGet("/area/{postcode:regex(^[0-9]{{3}}-[0-9]{{4}}$)}", (string postcode) => $"邮编：{postcode}");
// 从query参数中获取数据
app.MapGet("/answer", ([FromQuery(Name = "id")] int answerId) => $"[FromQUery]-请求的AnswerID为{answerId}");
// 从header获取数据
app.MapGet("/answers", ([FromHeader(Name = "key")] string secretkey) => $"[FromHeader]-secretkey为{secretkey}");
// 从路由中获取数据
app.MapGet("/question/{questiontype}", ([FromRoute]string questionType) => $"[FromRoute]-questiontype={questionType}");
// 从body中获取数据
app.MapPost("/answer", ([FromBody]Answer answer)=> $"[FromBody]-answer：{System.Text.Json.JsonSerializer.Serialize(answer)}");
// 从form表单中获取数据——API中不支持，需要网页表单提交才可
app.MapPost("/questiontype", ([FromForm]string questionTypeName) => $"[FromForm]-questionTypeName：{questionTypeName}");

app.Run();