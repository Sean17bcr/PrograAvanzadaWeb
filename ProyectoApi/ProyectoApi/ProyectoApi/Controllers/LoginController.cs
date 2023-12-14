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
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _connection;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public LoginController(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion(UsuarioEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<UsuarioEnt>("IniciarSesion",
                        new { entidad.usuario, entidad.contrasenna },
                        commandType: CommandType.StoredProcedure).FirstOrDefault();

                    if (datos != null)
                    {
                        _httpContextAccessor.HttpContext.Session.SetString("IdUsuario", datos.IdUsuario.ToString());
                        return Ok(datos);
                    }
                    else
                    {
                        return BadRequest("No se logró validar su información");
                    }

                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
