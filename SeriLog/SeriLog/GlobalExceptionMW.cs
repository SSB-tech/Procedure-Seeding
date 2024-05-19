using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System.Threading.Tasks;

namespace SeriLogProject
{
    public class GlobalExceptionMW : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                Log.Logger = new LoggerConfiguration().WriteTo.Seq("http://localhost:5341").CreateLogger(); //to show in seq (optional)
                Log.Error(ex, ex.Message); //Will log in db, file, and serilog ui
            }
        }

    }
}