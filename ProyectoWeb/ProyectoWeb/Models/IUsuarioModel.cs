using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public interface IUsuarioModel
    {
        public int RegistrarUsuario(UsuarioEnt entidad);
        public List<UsuarioEnt>? ObtenerTodosLosUsuarios();
        public int ActualizarUsuario(UsuarioEnt entidad);
        public int EliminarUsuarioPorId(long q);
        public List<UsuarioEnt>? ObtenerUsuarioPorId(long q);
        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad);
    }
}
