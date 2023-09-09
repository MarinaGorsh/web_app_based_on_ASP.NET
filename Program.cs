//using App;
//var builder = WebApplication.CreateBuilder(args);
//var app = builder.Build();

//app.MapGet("/",async context =>
//{
//    var company = new Company("Privat bank", 1992);
//    await context.Response.WriteAsync($"Company name: {company.name}, Year of foundation: {company.yearOfCr}");
//});

//app.Run();


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    var random = new Random();
    var randomNumber = random.Next(0, 101);
    await context.Response.WriteAsync($"Random Number: {randomNumber}");
});

app.Run();
