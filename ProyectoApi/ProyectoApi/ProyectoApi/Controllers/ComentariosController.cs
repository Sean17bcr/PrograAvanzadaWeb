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
    public class ComentariosController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private string _connection;
        public ComentariosController(IConfiguration configuration)
        {
            _configuration = configuration;
            _connection = _configuration.GetConnectionString("DefaultConnection");

        }

        [HttpPost]
        [Route("RegistrarComentario")]
        public IActionResult RegistrarComentario(ComentariosEnt entidad)
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("RegistrarComentario",
                        new {entidad.IdUsuario, entidad.comentario},
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
        [Route("VerComentarios")]
        public IActionResult VerComentarios()
        {
            try
            {
                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Query<ComentariosEnt>("VerComentarios",
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

        

        [HttpDelete]
        [Route("EliminarComentarioPorId")]
        public IActionResult EliminarComentarioPorId(long q)
        {
            try
            {
                long IdComentario = q;

                using (var context = new SqlConnection(_connection))
                {
                    var datos = context.Execute("EliminarComentarioPorId",
                        new { IdComentario },
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
