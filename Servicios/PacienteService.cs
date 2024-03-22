using DTOs;
using LaboratorioBlazorUI.DTOs;
using Newtonsoft.Json;

namespace LaboratorioBlazorUI.Servicios
{
    public class PacienteService : IPacienteService
    {
        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Cliente/";

        public PacienteService(HttpClient client)
        {
            this._client = client;

        }

        public async Task<PacienteObtencionDTO> BuscarPaciente(string documento)
        {

            try
            {


                // Construye la URL completa para la solicitud GET
                string apiUrl = $"{_Url}BuscarPacientePorDocumento {documento}";

                // Realiza la solicitud GET
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var paciente = JsonConvert.DeserializeObject<PacienteObtencionDTO>(content);
                    return paciente;
                }
                else
                {

                    throw new Exception($"Error al obtener el paciente. Estado de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
