var builder = WebApplication.CreateBuilder();
//builder.Logging.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt"));
var app = builder.Build();

app.UseMiddleware<MiddlewareFile>();

app.Map("/submit", async (context) =>
{
    string name = context.Request.Form["name"];
    string datetime = context.Request.Form["datetime"];

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(datetime))
    {
        if (DateTime.TryParse(datetime, out DateTime dataTime))
        {
            context.Response.Cookies.Append("name", name, new CookieOptions
            {
                Expires = dataTime,
            });

            await context.Response.WriteAsync($"Name - {name}, Time - {dataTime}");
        }
    }
});


app.Run(async (context) =>
{
    int a = 5;
    int b = 0;
    int c = a / b;
    await context.Response.WriteAsync($"c = {c}");
});
app.Run();
