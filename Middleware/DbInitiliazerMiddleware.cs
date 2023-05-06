using DemoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Middleware;

public class DbInitiliazerMiddleware
{
    private readonly RequestDelegate _next;

    public DbInitiliazerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AppDbContext db)
    {
       db.Database.EnsureCreated();
       await _next(context);
    }
}
