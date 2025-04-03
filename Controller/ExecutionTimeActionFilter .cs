using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

public class ExecutionTimeActionFilter : IActionFilter
{
    private readonly ILogger<ExecutionTimeActionFilter> _logger;
    private Stopwatch _stopwatch;

    public ExecutionTimeActionFilter(ILogger<ExecutionTimeActionFilter> logger)
    {
        _logger = logger;
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        _stopwatch = Stopwatch.StartNew();
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
        _stopwatch.Stop();
        var elapsedTime = _stopwatch.ElapsedMilliseconds;
        _logger.LogInformation($"[{context.ActionDescriptor.DisplayName}] çalıştırma süresi: {elapsedTime} ms");
    }
}



