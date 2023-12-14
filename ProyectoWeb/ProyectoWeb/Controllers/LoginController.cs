using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;
using System.Diagnostics;

namespace ProyectoWeb.Controllers
{
    [ResponseCache(NoStore = true, Duration = 0)]
    public class LoginController : Controller
    {
        private readonly IUsuarioModel _usuarioModel;
        private readonly IProductoModel _productoModel;
        private readonly ICarritoModel _carritoModel;

        public LoginController(IUsuarioModel usuarioModel, IProductoModel productoModel, ICarritoModel carritoModel)
        {
            _usuarioModel = usuarioModel;
            _productoModel = productoModel;
            _carritoModel = carritoModel;
        }

        

        [HttpGet]
        public IActionResult Index()
        {
            var datos = _productoModel.ConsultarProductos().ToList();
            return View(datos);
        }


        [HttpGet]
        public IActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }


        [HttpGet]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IniciarSesion(UsuarioEnt entidad)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = _usuarioModel.IniciarSesion(entidad);

            if (resp != null)
            {
                HttpContext.Session.SetString("NombreUsuario", resp.nombre);
                HttpContext.Session.SetString("IdUsuario", resp.IdUsuario.ToString());
                HttpContext.Session.SetString("RolUsuario", resp.ConRol.ToString());



                var datos = _carritoModel.ConsultarCarrito();
                if (datos != null)
                {
                    HttpContext.Session.SetString("Total", datos.Sum(x => x.Total).ToString());
                    HttpContext.Session.SetString("Cantidad", datos.Sum(x => x.Cantidad).ToString());
                }
                    

                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MensajePantalla = "No se pudo validar su cuenta";
                return View();
            }
        }


        [HttpGet]
        public IActionResult RegistrarCuenta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarCuenta(UsuarioEnt entidad)
        {
            if (!ModelState.IsValid)
                return View();

            var resp = _usuarioModel.RegistrarUsuario(entidad);

            if (resp == 1)
                return RedirectToAction("IniciarSesion", "Login");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su cuenta";
                return View();
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}