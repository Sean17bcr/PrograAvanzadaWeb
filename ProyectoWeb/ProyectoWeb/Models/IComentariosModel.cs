using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public interface IComentariosModel
    {
        public List<ComentariosEnt>? VerComentarios();
        public int RegistrarComentario(ComentariosEnt entidad);
        public int EliminarComentarioPorId(long q);
    }
}
