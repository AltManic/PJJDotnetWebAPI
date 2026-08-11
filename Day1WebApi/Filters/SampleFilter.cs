using Microsoft.AspNetCore.Mvc.Filters;

namespace Day1WebApi.Filters
{
    public class SampleFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine("Sample filter selesai");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("Sample filter dimulai");
        }
    }

    public class SampleFilterAttribute : TypeFilterAttribute
    {
        public SampleFilterAttribute() : base(typeof(SampleFilter))
        {
        }
    }
}
