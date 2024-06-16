using Microsoft.AspNetCore.Mvc;

namespace THIA_Tech.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
