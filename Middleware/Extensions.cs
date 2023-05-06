using DemoApp.Data;

namespace DemoApp.Middleware
{
    public static class AppMiddlewareExtensions
    {
        public static IApplicationBuilder UseDbInitializer(this IApplicationBuilder app)
        {
            return app.UseMiddleware<DbInitiliazerMiddleware>();
        }
    }
}
