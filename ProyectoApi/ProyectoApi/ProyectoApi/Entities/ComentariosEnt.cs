namespace ProyectoApi.Entities
{
    public class ComentariosEnt
    {
        public long IdComentarios { get; set; }
        public long IdUsuario { get; set; }
        public string comentario { get; set; } = string.Empty;
    }
}
