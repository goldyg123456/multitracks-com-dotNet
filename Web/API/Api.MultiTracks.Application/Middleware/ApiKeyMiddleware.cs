using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.MultiTracks.Application.Middleware
{
    public class ApiKeyMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = next;
        private const string APIKEY = "XApiKey";

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(APIKEY, out var extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Api Key was not provided ");
                return;
            }

            var appSettings = context.RequestServices.GetRequiredService<IConfiguration>();
            var apiKey = appSettings.GetValue<string>(APIKEY);

            if (string.IsNullOrEmpty(apiKey))
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Api Key is not configured");
                return;
            }

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Unauthorized client");
                return;
            }

            await _next(context);
        }
    }
}
