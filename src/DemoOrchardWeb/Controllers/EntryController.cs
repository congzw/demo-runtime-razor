using Microsoft.AspNetCore.Mvc;

namespace DemoOrchardWeb.Controllers
{
    public class EntryController : MvcController
    {
        [Route("/")]
        public IActionResult Root()
        {
            return View();
        }
    }
}
