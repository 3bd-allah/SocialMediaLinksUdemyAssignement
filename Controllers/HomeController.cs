using Microsoft.AspNetCore.Mvc;

namespace SocialMediaLinks.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return Json(new { });
        }
    }
}
