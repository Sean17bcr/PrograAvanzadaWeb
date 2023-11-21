namespace ProyectoApi.Entities
{
    public class DetallePedidoEnt
    {
        public long IdDetallePedido { get; set; }
        public long IdPedido { get; set; }
        public long IdProducto { get; set; }
        public int cantidad { get; set; }

    }
}
