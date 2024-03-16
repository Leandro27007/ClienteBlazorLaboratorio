
using LaboratorioBlazorUI.Modelos;
using LaboratorioBlazorUI.Modelos.Request;

using System.Text;
using System.Text.Json;

namespace LaboratorioBlazorUI.Servicios
{
    public class TurnoService : ITurnoServices
    {
        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Turno/";

        public TurnoService(HttpClient client)
        {
            this._client = client;

        }

        public async Task<string> GenerarTurno(GenerarTurnoRequest turnoParaGenerar)
        {


            try
            {


                var turnoJson = JsonSerializer.Serialize(turnoParaGenerar);

                var contenido = new StringContent(turnoJson, Encoding.UTF8, "application/json");

                var respuesta = await _client.PostAsync(_Url + "GenerarTurno", contenido);

                respuesta.EnsureSuccessStatusCode();


                var respuestaARetornar = await respuesta.Content.ReadAsStringAsync();

                return respuestaARetornar;
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<List<Turno>> GetTurnos()
        {

            try
            {

                var response = await _client.GetAsync(_Url + "ListarTurnosPendientes");


                var content = await response.Content.ReadAsStringAsync();

                var turnos = JsonSerializer.Deserialize<List<Turno>>(content);

                return turnos;

            }
            catch (Exception ex)
            {

                throw;
            }


        }

        public async Task<string> CancelarTurno(string turnoId)
        {


            try
            {



                // Construye la URL completa del endpoint
                string endpointUrl = _Url + "CancelarTurno?TurnoId=" + turnoId;

                // Realiza la solicitud HTTP PUT
                var response = await _client.PutAsync(endpointUrl, null);
                // Lee el contenido de la respuesta como una cadena
                string responseContent = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    // Devuelve la respuesta deserializada como una cadena
                    return responseContent;
                }
                else
                {
                    return responseContent;
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
