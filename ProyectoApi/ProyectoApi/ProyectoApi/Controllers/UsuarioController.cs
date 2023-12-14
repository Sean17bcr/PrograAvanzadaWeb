using Microsoft.AspNetCore.Authorization;
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
    public class UsuarioController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _connection;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
            
        }


        [HttpPost]
        [Route("RegistrarUsuario")]
        public IActionResult RegistrarUsuario(UsuarioEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    
                    var datos = context.Execute("RegistrarUsuario",
                        new { 
                            entidad.identificacion,
                            entidad.nombre,
                            entidad.usuario,
                            entidad.correo,
                            entidad.contrasenna
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
        [Route("ObtenerTodosLosUsuarios")]
        public IActionResult ObtenerTodosLosUsuarios()
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<UsuarioEnt>("ObtenerTodosLosUsuarios",
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
        [Route("ActualizarUsuario")]
        public IActionResult ActualizarUsuario(UsuarioEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("ActualizarUsuario",
                        new
                        {
                            entidad.IdUsuario, 
                            //entidad.identificacion,
                            entidad.nombre,
                            entidad.usuario,
                            //entidad.correo,
                            //entidad.contrasenna,
                            entidad.ConRol,
                            entidad.estado,
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
        [Route("ObtenerUsuarioPorId")]
        public IActionResult ObtenerUsuarioPorId(long q)
        {
            try
            {
                long IdUsuario = q;

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<UsuarioEnt>("ObtenerUsuarioPorId",
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
        [HttpDelete]
        [Route("EliminarUsuarioPorId")]
        public IActionResult EliminarUsuarioPorId(long q)
        {
            try
            {
                long IdUsuario = q;

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("EliminarUsuarioPorId",
                        new { IdUsuario },
                        commandType: CommandType.StoredProcedure);

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
