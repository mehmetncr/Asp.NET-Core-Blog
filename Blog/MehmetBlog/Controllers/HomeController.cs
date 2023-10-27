using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
