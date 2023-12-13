using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class CarritoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
