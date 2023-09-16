var builder = WebApplication.CreateBuilder();
var app = builder.Build();

builder.Configuration
    .AddJsonFile("comp.json")
    .AddXmlFile("company.xml")
    .AddIniFile("compan.ini")
    .AddJsonFile("me.json");

app.Map("/", (IConfiguration appConfig) =>
{
    int max = 0;
    string compName = "";
    var companies = appConfig.GetSection("companies").GetChildren();

    foreach (var company in companies) {
        int emploees = company.GetValue<int>("employees");
        if (emploees > max) { 
            max = emploees;
            compName = company.GetValue<string>("name");
        }
    }

    return compName;
});
app.Map("/ex2", (IConfiguration appConfig) =>
{
    var me = appConfig.GetSection("me").GetChildren();
    var meList = new List<string>();
    foreach (var inf in me) {
        var infa = inf.Value;
        meList.Add(infa);
    }
    return meList;
});
app.Run();
