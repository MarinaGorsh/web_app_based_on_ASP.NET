using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using System.Text;
using System.IO;


public class FileController : Controller
{
    public IActionResult DownloadFile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult DownloadFileTxt(UserModel model)
    {
        string fileName = $"{model.NameOfFile}.txt";
        string file = $"User Name: {model.UserName}\nUser Surname: {model.UserSurname}";
        byte[] buffer = Encoding.UTF8.GetBytes(file);
        return File(buffer, "text/plain", fileName);
    }
}
