public class OregonTechRedirectMiddleware
{
    private readonly RequestDelegate _next;

    public OregonTechRedirectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Response.StatusCode = 302; // Temporary redirect
        context.Response.Headers["Location"] = "https://www.oit.edu";
        // No call to _next(context); to short-circuit the pipeline
    }
}
