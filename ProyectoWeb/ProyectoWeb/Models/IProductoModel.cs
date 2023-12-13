using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public interface IProductoModel
    {
        public List<ProductoEnt>? ConsultarProductos();
        public int EditarProducto(ProductoEnt entidad);
        public int RegistrarProducto(ProductoEnt entidad);
        public int EliminarProductoPorId(long q);
    }
}
