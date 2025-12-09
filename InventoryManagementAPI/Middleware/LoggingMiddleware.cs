namespace InventoryManagementAPI.Middleware;

public class LoggingMiddleware
{
    private readonly RequestDelegate _next;

    public LoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path}");
        Console.WriteLine("---------------------------------------------------------------");
        await _next(context);
    }
}