using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public interface IReservasModel
    {
        public List<ReservasEnt>? ObtenerTodasLasReservas();
        public int ActualizarReserva(ReservasEnt entidad);
        public int InsertarReserva(ReservasEnt entidad);
        public int EliminarReservaPorId(long q);
        public List<ReservasEnt>? ObtenerReservasdeUser(long q);
    }
}
