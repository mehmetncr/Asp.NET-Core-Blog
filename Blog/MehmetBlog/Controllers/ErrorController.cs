using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index(int code)
        {
            return View();
        }
    }
}
