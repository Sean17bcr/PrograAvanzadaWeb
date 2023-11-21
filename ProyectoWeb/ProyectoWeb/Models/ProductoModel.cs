using Microsoft.AspNetCore.Mvc;
using ProyectoWeb.Entities;
using System.Net.Http.Headers;
using System.Net.Http;

namespace ProyectoWeb.Models
{
    public class ProductoModel : IProductoModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;
        public ProductoModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }
        
        public List<ProductoEnt>? ConsultarProductos()
        {
            string url = _urlApi + "api/Producto/ConsultarProductos";

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<ProductoEnt>>().Result;
            else
                return null;
        }
        public int EditarProducto(ProductoEnt entidad)
        {
            string url = _urlApi + "api/Prroducto/EditarProducto";

            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public int RegistrarProducto(ProductoEnt entidad)
        {
            string url = _urlApi + "api/Producto/RegistrarProducto";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

    }
}
