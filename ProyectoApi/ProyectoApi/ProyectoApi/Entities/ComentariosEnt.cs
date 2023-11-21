namespace ProyectoApi.Entities
{
    public class ComentariosEnt
    {
        public long IdComentarios { get; set; }
        public long IdCliente { get; set; }
        public string comentario { get; set; } = string.Empty;
        public string cantEstrellas { get; set; } = string.Empty;
    }
}
