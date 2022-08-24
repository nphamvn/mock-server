using Microsoft.AspNetCore.Mvc;
using MockServer.Entities;

namespace MockServer.Models;

public class CustomActionResult : IActionResult
{
    private readonly StaticResponse response;

    public CustomActionResult(StaticResponse response)
    {
        this.response = response;
    }
    public async Task ExecuteResultAsync(ActionContext context)
    {
        if (response == null)
        {
            context.HttpContext.Response.StatusCode = 404;
            await context.HttpContext.Response.WriteAsync("Request not found");
            return;
        }
        context.HttpContext.Response.StatusCode = response.StatusCode;
        if (!string.IsNullOrEmpty(response.Body))
        {
            await context.HttpContext.Response.WriteAsync(response.Body);
            return;
        }
        await context.HttpContext.Response.CompleteAsync();
    }
}