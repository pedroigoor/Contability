using Gs_Contability.Middlewares;

namespace Gs_Contability.Config
{
    public static class MiddlewaresConfig
    {
        public static void RegisterMiddlewares(this WebApplication app)
        {
            app.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
