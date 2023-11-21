namespace ProyectoApi.Entities
{
    public class ClienteEnt
    {
        public long IdCliente { get; set; }
        public long IdUsuario { get; set; }
        public string direccion { get; set; } = string.Empty;
        public string quejas { get; set; } = string.Empty;
        
    }
}
