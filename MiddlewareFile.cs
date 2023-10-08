public class MiddlewareFile
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    public MiddlewareFile(RequestDelegate next, ILogger<MiddlewareFile> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogInformation($"Request URL: {context.Request.Path}");
            var filePath = "logger.txt";
            File.AppendAllText(filePath, $"Error: {ex.Message}{Environment.NewLine}");

            throw;
        }
    }
}
