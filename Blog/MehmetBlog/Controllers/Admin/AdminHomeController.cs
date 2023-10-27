using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers.Admin
{
    public class AdminHomeController : Controller
    {
        public IActionResult Pswrd()
        {
            return View();
        }
    }
}
