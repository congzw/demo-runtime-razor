using System;
using System.IO;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace DemoOrchardWeb.Controllers
{
    public class HomeController : MvcController
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Root/Home/Append")]
        public IActionResult Append()
        {
            //a demo for dynamic edit razor page
            var razorPath = Path.Combine(_hostEnvironment.ContentRootPath, "Views/Home/Index.cshtml");
            var append = $"{Environment.NewLine}<div><p>append from server {DateTimeOffset.Now}</p></div>";
            System.IO.File.AppendAllText(razorPath, append);
            return View("Index");
        }
    }
}
