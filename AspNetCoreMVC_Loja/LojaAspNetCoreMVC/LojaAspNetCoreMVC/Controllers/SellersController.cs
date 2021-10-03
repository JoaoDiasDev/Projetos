using Microsoft.AspNetCore.Mvc;

namespace LojaAspNetCoreMVC.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
