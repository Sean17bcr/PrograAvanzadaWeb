﻿using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using ProyectoWeb.Models;

namespace ProyectoWeb.Controllers
{
    public class ProductoController : Controller
    {

        private readonly IProductoModel _productoModel;

        public ProductoController(IProductoModel productoModel)
        {
            _productoModel = productoModel;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EditarProducto(long q)
        {
            var entidad = new ProductoEnt();
            entidad.IdProducto = q;

            _productoModel.EditarProducto(entidad);
            return RedirectToAction("ConsultarUsuarios", "Producto");
        }


        [HttpPost]
        public IActionResult EditarProducto(ProductoEnt entidad)
        {
            var resp = _productoModel.EditarProducto(entidad);

            if (resp == 1)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.MensajePantalla = "No se pudo actualizar su cuenta";
                return View();
            }
        }

        [HttpGet]
        public IActionResult ConsultarProductos()
        {
            var datos = _productoModel.ConsultarProductos();
            return View(datos);
        }

        [HttpGet]
        public IActionResult RegistrarProducto()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegistrarProducto(ProductoEnt entidad)
        {
            var resp = _productoModel.RegistrarProducto(entidad);

            if (resp == 1)
                return RedirectToAction("ConsultarProductos", "Producto");
            else
            {
                ViewBag.MensajePantalla = "No se pudo registrar su cuenta";
                return View();
            }
        }

    }
}
