namespace ProyectoApi.Entities
{
    public class PedidoCanceladoEnt
    {
        public long IdPedidoCancelado { get; set; }
        public long IdPedido { get; set; }
        public string razon_cancelacion {  get; set; } = string.Empty;

    }
}
