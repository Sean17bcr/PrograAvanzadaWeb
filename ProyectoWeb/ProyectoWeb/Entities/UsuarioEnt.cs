namespace ProyectoWeb.Entities
{
    public class UsuarioEnt
    {
        public long IdUsuario { get; set; }
        public string identificacion { get; set; } = string.Empty;
        public string nombre { get; set; } = string.Empty;
        public string usuario { get; set; } = string.Empty;
        public string correo { get; set; } = string.Empty;
        public string contrasenna { get; set; } = string.Empty;
        public long ConRol { get; set; }
        public bool estado { get; set; }
    }
}
