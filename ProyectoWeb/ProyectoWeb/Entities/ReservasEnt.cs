namespace ProyectoWeb.Entities
{
    public class ReservasEnt
    {
        public long IdReservas { get; set; }
        public long IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public DateTime fecha_reserva { get; set; }
    }
}
