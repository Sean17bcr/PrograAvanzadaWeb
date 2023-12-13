using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public class UsuarioModel : IUsuarioModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;
        public UsuarioModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }
       
        
        public List<UsuarioEnt>? ObtenerTodosLosUsuarios()
        {
            string url = _urlApi + "api/Usuario/ObtenerTodosLosUsuarios";

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            else
                return null;
        }
        public int ActualizarUsuario(UsuarioEnt entidad)
        {
            string url = _urlApi + "api/Usuario/ActualizarUsuario";

            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        
        public int EliminarUsuarioPorId(long q)
        {
            string url = _urlApi + "api/Usuario/EliminarUsuarioPorId?q=" + q;

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }
        
        public List<UsuarioEnt>? ObtenerUsuarioPorId(long q)
        {
            string url = _urlApi + "api/Usuario/ObtenerUsuarioPorId?q=" + q; ;

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<UsuarioEnt>>().Result;
            else
                return null;
        }

        public UsuarioEnt? IniciarSesion(UsuarioEnt entidad)
        {
            string url = _urlApi + "api/Login/IniciarSesion";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<UsuarioEnt>().Result;
            else
                return null;
        }
        public int RegistrarUsuario(UsuarioEnt entidad)
        {
            string url = _urlApi + "api/Usuario/RegistrarUsuario";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

    }
}
