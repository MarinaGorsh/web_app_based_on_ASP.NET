using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication4.Filters
{
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string actionName = context.ActionDescriptor.RouteValues["action"];
            string controllerName = context.ActionDescriptor.RouteValues["controller"];
            DateTime timestamp = DateTime.Now;
            string message = $"{controllerName}.{actionName} викликано о {timestamp}";

            string filePath = @"C:\Users\Marina Gorshevskaya\source\repos\WebApplication4\WebApplication4\ActionLog.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(message);
            }
            base.OnActionExecuting(context);
        }
    }
}