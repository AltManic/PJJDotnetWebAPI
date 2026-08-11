using Day1WebApi.Extensions;

namespace Day1WebApi.Middlewares
{
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;
        public SampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            
            Console.WriteLine("Sample middleware dimulai");
            await _next(context);
            Console.WriteLine("Sample middleware selesai");
        }
    }
}
