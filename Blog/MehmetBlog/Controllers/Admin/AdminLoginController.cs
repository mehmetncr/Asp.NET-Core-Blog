using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers.Admin
{
    public class AdminLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
