var builder = WebApplication.CreateBuilder();
var app = builder.Build();

builder.Configuration
    .AddJsonFile("books.json")
    .AddJsonFile("users.json");

app.Map("/library", () => "Hello, user");
app.Map("/library/books", (IConfiguration appConfig) =>
{
    var books = appConfig.GetSection("books").GetChildren();
    List<string> listBooks = new List<string>();

    foreach (var book in books)
    {
        string bookName = book.GetValue<string>("name");
        listBooks.Add(bookName);
    }
    string result = string.Join("\n", listBooks);
    return result;
});
app.Map("/library/profile/id/{number:int:range(1, 5)}", (IConfiguration appConfig, int number) => {
    var users = appConfig.GetSection("users").GetChildren();
    List<string> userInfo = new List<string>();

    foreach (var user in users)
    {
        var id = user.GetValue<int>("id");
        if (number == id)
        {
            string name = user.GetValue<string>("name");
            string surname = user.GetValue<string>("surname");
            int year = user.GetValue<int>("year");
            string books = user.GetValue<string>("books");

            userInfo.Add($"Name: {name}");
            userInfo.Add($"Surname: {surname}");
            userInfo.Add($"Year of birth: {year}");

            if (!string.IsNullOrEmpty(books))
            {
                string[] bookIds = books.Split(',').Select(s => s.Trim()).ToArray();
                userInfo.Add("Books:");
                foreach (string bookId in bookIds)
                {
                    int bookNumber;
                    if (int.TryParse(bookId, out bookNumber))
                    {
                        var bookInfo = appConfig.GetSection("books")
                            .GetChildren()
                            .FirstOrDefault(b => b.GetValue<int>("number") == bookNumber);

                        if (bookInfo != null)
                        {
                            string bookName = bookInfo.GetValue<string>("name");
                            userInfo.Add($"- {bookName}");
                        }
                    }
                }
            }

            break;
        }
    }
    string result = string.Join("\n", userInfo);
    return result;
});

app.Map("/library/profile/id", (IConfiguration appConfig) => {
    var users = appConfig.GetSection("users").GetChildren();
    List<string> userInfo = new List<string>();

    foreach (var user in users)
    {
        var id = user.GetValue<int>("id");
        if (id == 1)
        {
            string name = user.GetValue<string>("name");
            string surname = user.GetValue<string>("surname");
            int year = user.GetValue<int>("year");
            string books = user.GetValue<string>("books");

            userInfo.Add($"Name: {name}");
            userInfo.Add($"Surname: {surname}");
            userInfo.Add($"Year of birth: {year}");

            if (!string.IsNullOrEmpty(books))
            {
                string[] bookIds = books.Split(',').Select(s => s.Trim()).ToArray();
                userInfo.Add("Books:");
                foreach (string bookId in bookIds)
                {
                    int bookNumber;
                    if (int.TryParse(bookId, out bookNumber))
                    {
                        var bookInfo = appConfig.GetSection("books")
                            .GetChildren()
                            .FirstOrDefault(b => b.GetValue<int>("number") == bookNumber);

                        if (bookInfo != null)
                        {
                            string bookName = bookInfo.GetValue<string>("name");
                            userInfo.Add($"- {bookName}");
                        }
                    }
                }
            }

            break;
        }
    }
    string result = string.Join("\n", userInfo);
    return result;
});
app.Run();

