using WebApplication3;

var builder = WebApplication.CreateBuilder();
builder.Services.AddTransient<CalcService>();
builder.Services.AddTransient<ITimeService, ShortTimeService>();
var app = builder.Build();

app.Map("/ex1", async context =>
{
    var calc = app.Services.GetService<CalcService>();
    await context.Response.WriteAsync($"Sum: {calc.Sum(5, 8)}\n");
    await context.Response.WriteAsync($"Minus: {calc.Minus(8, 5)}\n");
    await context.Response.WriteAsync($"Multiple: {calc.Multiple(5, 8)} \n");
    await context.Response.WriteAsync($"Divide: {calc.Divide(8, 2)} \n");
});
app.Map("/ex2", async context =>
{
    var time = app.Services.GetService<ITimeService>();
    await context.Response.WriteAsync($"Time: {time?.GetTime()}");
});
app.Run();

