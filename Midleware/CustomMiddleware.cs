namespace Midleware;

public class CustomMiddleware(RequestDelegate next)
{

    public async Task InvokeAsync(HttpContext ctx)
    {
        Console.WriteLine("Class middleware: entering");
        await next.Invoke(ctx);
        Console.WriteLine("Class middleware: exiting");
    }
}