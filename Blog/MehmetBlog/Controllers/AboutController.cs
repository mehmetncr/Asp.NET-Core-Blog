using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()   //hakkımızda sayfası döndürür sadece
        {
            return View();
        }
    }
}
