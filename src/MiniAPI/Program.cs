var app = WebApplication.Create();
app.MapGet("/", () => "Hello World!");
app.Run();