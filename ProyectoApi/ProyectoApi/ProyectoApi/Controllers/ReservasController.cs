using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoApi.Entities;
using System.Data.SqlClient;
using System.Data;
using Dapper;

namespace ProyectoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservasController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _connection;
        public ReservasController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");

        }

        [HttpPost]
        [Route("InsertarReserva")]
        public IActionResult InsertarReserva(ReservasEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("InsertarReserva",
                        new { 
                            entidad.IdUsuario,
                            entidad.fecha_reserva
                        },
                        commandType: CommandType.StoredProcedure);

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerTodasLasReservas")]
        public IActionResult ObtenerTodasLasReservas()
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<ReservasEnt>("ObtenerTodasLasReservas",
                        new { },
                        commandType: CommandType.StoredProcedure).ToList();

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("ActualizarReserva")]
        public IActionResult ActualizarReserva(ReservasEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("ActualizarReserva",
                        new
                        {
                            entidad.IdReservas,
                            entidad.IdUsuario,
                            entidad.fecha_reserva
                        },
                        commandType: CommandType.StoredProcedure);

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("EliminarReservaPorId")]
        public IActionResult EliminarReservaPorId(long q)
        {
            try
            {
                long IdReservas = q;

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("EliminarReservaPorId",
                        new { IdReservas },
                        commandType: CommandType.StoredProcedure);

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("ObtenerReservasdeUser")]
        public IActionResult ObtenerReservasdeUser(long q)
        {
            try
            {
                long IdUsuario = q;

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<ReservasEnt>("ObtenerReservasdeUser",
                        new { IdUsuario },
                        commandType: CommandType.StoredProcedure).ToList();

                    return Ok(datos);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
