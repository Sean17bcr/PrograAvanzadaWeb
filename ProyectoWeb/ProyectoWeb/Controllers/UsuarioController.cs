using Microsoft.AspNetCore.Mvc;

namespace ProyectoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
