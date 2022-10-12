using Microsoft.AspNetCore.Mvc;

namespace sistemaDual.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
