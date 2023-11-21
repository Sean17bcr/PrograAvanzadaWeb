namespace ProyectoWeb.Entities
{
    public class ProductoEnt
    {
        public long IdProducto { get; set; }
        public string nombre { get; set; } = string.Empty;
        public string descripcion { get; set; } = string.Empty;
        public float precio { get; set; }
        public string imagen {get; set; } = string.Empty;

    }
}
