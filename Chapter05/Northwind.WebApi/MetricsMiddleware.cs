using System.Diagnostics;

namespace Northwind.WebApi;

public class MetricsMiddleware
{
    private readonly RequestDelegate _next;
    private readonly MetricsService _metricsService;

    public MetricsMiddleware(MetricsService metricsService, RequestDelegate next)
    {
        _metricsService = metricsService;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Stopwatch timer = Stopwatch.StartNew();

        // Call the next middleware in the pipeline
        await _next(context);

        timer.Stop();

        if (!context.Request.Path.StartsWithSegments("/api/metrics"))
        {
            _metricsService.IncrementRequestCount();
            _metricsService.RecordRequestDuration(timer.ElapsedMilliseconds);
        }

    }

}

public static class MetricsMiddlewareExtensions
{
    public static IApplicationBuilder UseMetricsMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<MetricsMiddleware>();
    }
}
