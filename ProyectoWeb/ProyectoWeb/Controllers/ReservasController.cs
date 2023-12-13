using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class ReservasController : Controller
    {
        private readonly IReservasModel _reservasModel;

        public ReservasController(IReservasModel reservasModel)
        {
            _reservasModel = reservasModel;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ActualizarReserva(long q)
        {
            var datos = _reservasModel.ObtenerTodasLasReservas().Where(x => x.IdReservas == q).FirstOrDefault();
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
            var datos = _reservasModel.ObtenerTodasLasReservas();
            return View(datos);
        }

        [HttpGet]
        public IActionResult InsertarReserva()
        {
            return View();
        }

        [HttpPost]
        public IActionResult InsertarReserva(ReservasEnt entidad)
        {
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
        public IActionResult EliminarProductoPorId(long q)
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
