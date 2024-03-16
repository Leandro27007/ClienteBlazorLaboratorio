using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using LaboratorioBlazorUI.Modelos.Request;
using LaboratorioBlazorUI.Modelos.Response;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace LaboratorioBlazorUI.Servicios
{
    public class ReciboService : IReciboService
    {
        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Recibo/";
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public ReciboService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            this._client = client;

            this._authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<ReciboResponse> GenerarRecibo(ReciboRequest recibo)
        {

            try
            {

                recibo.idCajero = "40200000000";

                var reciboJson = JsonSerializer.Serialize(recibo);


                var contenido = new StringContent(reciboJson, Encoding.UTF8, "application/json");

                var respuesta = await _client.PostAsync(_Url + "GenerarRecibo", contenido);

                respuesta.EnsureSuccessStatusCode();

                var respuestaARetornar = await respuesta.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<ReciboResponse>(respuestaARetornar);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<ReciboDTO>> ListarRecibos()
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var accessTokenClaim = user.FindFirst("access_token");
            var accessToken = accessTokenClaim.Value!;


            try
            {


                var respuesta = await _client.GetAsync(_Url + "ListarRecibos?PaginaActual=1");

                respuesta.EnsureSuccessStatusCode();

                var respuestaARetornar = await respuesta.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<List<ReciboDTO>>(respuestaARetornar);

                return response;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<bool> Reembolsar(ReembolsoRequest reembolsoRequest)
        {


            try
            {

                // Construye la URL completa para la solicitud POST
                string apiUrl = $"{_Url}CancelarRecibo";

                // Crea un objeto HttpRequestMessage para especificar la solicitud
                var request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post, apiUrl);

                // Agrega los valores a los encabezados
                request.Headers.Add("IdRecibo", reembolsoRequest.IdRecibo);
                request.Headers.Add("notaModificacion", reembolsoRequest.notaModificacion);

                // Realiza la solicitud POST
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    // La solicitud fue exitosa
                    return true;
                }
                else
                {
                    // Si la respuesta no es exitosa, maneja el error según tus necesidades
                    // Puedes lanzar una excepción, registrar el error, o tomar otra acción.
                    throw new Exception($"Error al cambiar el estado del recibo. Estado de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
