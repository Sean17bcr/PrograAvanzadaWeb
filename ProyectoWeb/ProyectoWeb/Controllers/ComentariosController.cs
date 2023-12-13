using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class ComentariosController : Controller
    {
        private readonly IComentariosModel _comentariosModel;

        public ComentariosController(IComentariosModel comentariosModel)
        {
            _comentariosModel = comentariosModel;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult VerComentarios()
        {
            var datos = _comentariosModel.VerComentarios();
            return View(datos);
        }

        [HttpGet]
        public IActionResult RegistrarComentario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarComentario(ComentariosEnt entidad)
        {
            var resp = _comentariosModel.RegistrarComentario(entidad);

            if (resp == 1)
                return RedirectToAction("VerComentarios", "Comentarios");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su cuenta";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EliminarComentarioPorId(long q)
        {
            _comentariosModel.EliminarComentarioPorId(q);

            return RedirectToAction("VerComentarios", "Comentarios");
        }
    }
}
