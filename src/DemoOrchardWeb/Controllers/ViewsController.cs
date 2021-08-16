using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace DemoOrchardWeb.Controllers
{
    public class ViewsController : MvcController
    {
        private readonly IWebHostEnvironment _env;

        public ViewsController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [Route("/Views/{view}")]
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

        //only for demo
        //todo: delete this method
        [Route("/Views/Demo/Append")]
        public IActionResult DemoAppend()
        {
            //a demo for dynamic edit razor page
            var razorPath = Path.Combine(_env.ContentRootPath, "Views/Demo/Index.cshtml");
            //var append = $"{Environment.NewLine}<div><p style=\"color: red\">append at {DateTimeOffset.Now} webRootPath:{_env.WebRootPath} contentRootPath:{_env.ContentRootPath}</p></div>";
            var append = $"{Environment.NewLine}<div><p style=\"color: red\">append at {DateTimeOffset.Now}</p></div>";
            System.IO.File.AppendAllText(razorPath, append);
            return View("../Demo/Index");
        }
    }
}