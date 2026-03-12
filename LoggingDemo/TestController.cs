using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace LoggingDemo;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet("info")]
    public IActionResult TestInfoLog()
    {
        _logger.LogInformation("This is an information level log from ILogger");
        Log.Information("This is an information level log from static Log");
        return Ok("Information log test completed");
    }

    [HttpGet("warning")]
    public IActionResult TestWarningLog()
    {
        _logger.LogWarning("This is a warning level log from ILogger");
        Log.Warning("This is a warning level log from static Log");
        return Ok("Warning log test completed");
    }

    [HttpGet("error")]
    public IActionResult TestErrorLog()
    {
        try
        {
            throw new InvalidOperationException("This is a test exception for error logging");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "This is an error level log with exception from ILogger");
            Log.Error(ex, "This is an error level log with exception from static Log");
        }

        return Ok("Error log test completed");
    }
}