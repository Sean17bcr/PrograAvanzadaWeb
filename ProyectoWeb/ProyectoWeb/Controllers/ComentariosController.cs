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
            
            if (HttpContext.Session.GetString("RolUsuario") == "1")
            {
                var datos = _comentariosModel.VerComentarios();
                return View(datos);
            }
            else if (HttpContext.Session.GetString("RolUsuario") == "3")
            {
                
                string idUsuarioString = HttpContext.Session.GetString("IdUsuario");
                if (long.TryParse(idUsuarioString, out long idUsuario))
                {
                    var id = idUsuario;
                    var datos = _comentariosModel.VerComentarios().Where(x => x.IdUsuario == id).ToList();
                    return View(datos);
                }
            }


            return View();
        }

        [HttpGet]
        public IActionResult RegistrarComentario()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarComentario(ComentariosEnt entidad)
        {
            string idUsuarioString = HttpContext.Session.GetString("IdUsuario");
            if (long.TryParse(idUsuarioString, out long idUsuario))
            {
                entidad.IdUsuario = idUsuario;
            }


            var resp = _comentariosModel.RegistrarComentario(entidad);

            if (resp == 1)
                return RedirectToAction("VerComentarios", "Comentarios");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su comentario";
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
