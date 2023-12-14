using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservasModel _reservasModel;
        private readonly IUsuarioModel _UsuarioModel;

        public ReservasController(IReservasModel reservasModel)
        {
            _reservasModel = reservasModel;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActualizarReserva(long q, long i)
        {
            var datos = _reservasModel.ObtenerTodasLasReservas().Where(x => x.IdReservas == q && x.IdUsuario == i).FirstOrDefault();
            return View(datos);
        }


        [HttpPost]
        public IActionResult ActualizarReserva(ReservasEnt entidad)
        {
            var resp = _reservasModel.ActualizarReserva(entidad);

            if (resp == 1)
            {
                return RedirectToAction("ObtenerTodasLasReservas", "Reservas");
            }
            else
            {
                ViewBag.MensajePantalla = "No se pudo actualizar la reserva";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ObtenerTodasLasReservas()
        {


            if (HttpContext.Session.GetString("RolUsuario") == "1" || HttpContext.Session.GetString("RolUsuario") == "2")
            {

                var datos = _reservasModel.ObtenerTodasLasReservas();

                return View(datos);
            }
            else if (HttpContext.Session.GetString("RolUsuario") == "3")
            {
                string idUsuarioString = HttpContext.Session.GetString("IdUsuario");
                if (long.TryParse(idUsuarioString, out long idUsuario))
                {
                    var id = idUsuario;
                    var datos = _reservasModel.ObtenerTodasLasReservas().Where(x => x.IdUsuario == id).ToList();
                    return View(datos);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult InsertarReserva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertarReserva(ReservasEnt entidad)
        {
            string idUsuarioString = HttpContext.Session.GetString("IdUsuario");
            if (long.TryParse(idUsuarioString, out long idUsuario))
            {
                entidad.IdUsuario = idUsuario;
            }

            var resp = _reservasModel.InsertarReserva(entidad);

            if (resp == 1)
                return RedirectToAction("ObtenerTodasLasReservas", "Reservas");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su Reserva";
                return View();
            }
        }

        [HttpGet]
        public IActionResult EliminarReservaPorId(long q)
        {
            _reservasModel.EliminarReservaPorId(q);

            return RedirectToAction("ObtenerTodasLasReservas", "Reservas");
        }

        [HttpGet]
        public IActionResult ObtenerReservasdeUser(long q)
        {
            var datos = _reservasModel.ObtenerReservasdeUser(q);
            return View(datos);
        }
    }
}
