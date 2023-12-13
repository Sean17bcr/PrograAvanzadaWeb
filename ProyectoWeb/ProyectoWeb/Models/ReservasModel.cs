using ProyectoWeb.Entities;

namespace ProyectoWeb.Models
{
    public class ReservasModel : IReservasModel
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _HttpContextAccessor;
        private string _urlApi;
        public ReservasModel(HttpClient httpClient, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _HttpContextAccessor = httpContextAccessor;
            _urlApi = _configuration.GetSection("Llaves:urlApi").Value;
        }

        public List<ReservasEnt>? ObtenerTodasLasReservas()
        {
            string url = _urlApi + "api/Reservas/ObtenerTodasLasReservas";

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<ReservasEnt>>().Result;
            else
                return null;
        }
        public int ActualizarReserva(ReservasEnt entidad)
        {
            string url = _urlApi + "api/Reservas/ActualizarReserva";

            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PutAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }

        public int InsertarReserva(ReservasEnt entidad)
        {
            string url = _urlApi + "api/Reservas/InsertarReserva";
            JsonContent obj = JsonContent.Create(entidad);
            var resp = _httpClient.PostAsync(url, obj).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }
        public int EliminarReservaPorId(long q)
        {
            string url = _urlApi + "api/Reservas/EliminarReservaPorId?q=" + q;

            var resp = _httpClient.DeleteAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<int>().Result;
            else
                return 0;
        }
        public List<ReservasEnt>? ObtenerReservasdeUser(long q)
        {
            string url = _urlApi + "api/Reservas/ObtenerReservasdeUser?q=" + q; ;

            var resp = _httpClient.GetAsync(url).Result;

            if (resp.IsSuccessStatusCode)
                return resp.Content.ReadFromJsonAsync<List<ReservasEnt>>().Result;
            else
                return null;
        }


    }
}
