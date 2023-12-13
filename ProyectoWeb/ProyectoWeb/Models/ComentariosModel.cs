using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public class ComentariosModel : IComentariosModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;
        public ComentariosModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public List<ComentariosEnt>? VerComentarios()
        {
            string url = _urlApi + "api/Comentarios/VerComentarios";

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<ComentariosEnt>>().Result;
            else
                return null;
        }
        

        public int RegistrarComentario(ComentariosEnt entidad)
        {
            string url = _urlApi + "api/Comentarios/RegistrarComentario";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }
        public int EliminarComentarioPorId(long q)
        {
            string url = _urlApi + "api/Comentarios/EliminarComentarioPorId?q=" + q;

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }
    }
}
