using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoOrchardWeb.Controllers
{
    public class RazorController : Controller
    {
        private readonly ILogger<RazorController> _logger;

        public RazorController(ILogger<RazorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Render(string view)
        {
            if (string.IsNullOrWhiteSpace(view))
            {
                return View("NotFound");
            }

            //"~/Foo.Home.Index"=>"../Foo/Home/Index";
            var viewPath = "../" + view.TrimStart('~').TrimStart('/').Replace(".", "/");
            ViewBag.Message = $"Render for {viewPath}";
            return View(viewPath);
        }
    }
}