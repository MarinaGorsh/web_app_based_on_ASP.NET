using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;

namespace WebApplication4.Filters
{
    public class UniqueUsersFilter : ActionFilterAttribute
    {
        public Dictionary<string, bool> uniqueUsers = new Dictionary<string, bool>();

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string userIdentifier = context.HttpContext.Connection.RemoteIpAddress.ToString();
            if (!uniqueUsers.ContainsKey(userIdentifier))
            {
                uniqueUsers[userIdentifier] = true;

                LogUserCount(uniqueUsers.Count);
            }
        }

        public void LogUserCount(int count)
        {
            string filePath = @"C:\Users\Marina Gorshevskaya\source\repos\WebApplication4\WebApplication4\UniqUsers.txt";

            DateTime timestamp = DateTime.Now;
            string logMessage = $"{timestamp}: Кількість унікальних користувачів: {count}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }
    }
}
