using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;

        public UsuarioController(IUsuarioModel usuarioModel)
        {
            _usuarioModel = usuarioModel;
        }

        [HttpGet]
        public IActionResult ObtenerUsuarioPorId(long q)
        {
            var datos = _usuarioModel.ObtenerUsuarioPorId(q);
            return View(datos);
        }

        
        [HttpGet]
        public IActionResult EditarProducto(long q)
        {
            var datos = _usuarioModel.ObtenerTodosLosUsuarios().Where(x => x.IdUsuario == q).FirstOrDefault();
            return View(datos);
        }


        [HttpPost]
        public IActionResult ActualizarUsuario(UsuarioEnt entidad)
        {
            var resp = _usuarioModel.ActualizarUsuario(entidad);

            if (resp == 1)
            {
                return RedirectToAction("ObtenerTodosLosUsuarios", "Usuario");
            }
            else
            {
                ViewBag.MensajePantalla = "No se pudo actualizar el usuario";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ObtenerTodosLosUsuarios()
        {
            var datos = _usuarioModel.ObtenerTodosLosUsuarios();
            return View(datos);
        }

        [HttpGet]
        public IActionResult RegistrarUsuario()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            var resp = _usuarioModel.RegistrarUsuario(entidad);

            if (resp == 1)
                return RedirectToAction("Index", "Login");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su cuenta";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EliminarUsuarioPorId(long q)
        {
            _usuarioModel.EliminarUsuarioPorId(q);

            return RedirectToAction("ObtenerTodosLosUsuarios", "Usuario");
        }

    }
}
