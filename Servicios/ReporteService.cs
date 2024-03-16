using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;
using System.Text.Json;

namespace LaboratorioBlazorUI.Servicios
{
    public class ReporteService : IReporteService
    {
        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Reporte/";

        public ReporteService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            this._client = client;

        }

        public async Task<ReporteDTO> ObtenerReporte(string FechaInicio, string FechaFinal)
        {

            try
            { 

                var respuesta = await _client.GetAsync(_Url + $"ListarPruebas?FechaInicio={FechaInicio}&FechaFinal={FechaFinal}");

                respuesta.EnsureSuccessStatusCode();

                var respuestaARetornar = await respuesta.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<ReporteDTO>(respuestaARetornar);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
