using DTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;

using System.Text;

namespace LaboratorioBlazorUI.Servicios
{
    public class UsuarioService : IUsuarioServices
    {

        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Usuario/";
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public UsuarioService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            this._authenticationStateProvider = authenticationStateProvider;
            this._client = client;

        }


        public async Task<UsuarioDTO> BuscarUsuario(string Cedula)
        {
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var accessTokenClaim = user.FindFirst("access_token");
            var accessToken = accessTokenClaim.Value!;

            throw new NotImplementedException();
        }

        public async Task<UsuarioDTO> CrearUsuario(UsuarioCreacionDTO usuarioCreacion)
        {


            try
            {

                // Construye la URL completa para la solicitud POST
                string apiUrl = $"{_Url}CrearUsuario";

                // Serializa el objeto CreacionPruebaLabDTO a JSON
                var jsonContent = JsonConvert.SerializeObject(usuarioCreacion);

                // Configura el contenido de la solicitud
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST
                var response = await _client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta y deserialízalo en un objeto PruebaLab
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var usuario = JsonConvert.DeserializeObject<UsuarioDTO>(responseContent);
                    return usuario;
                }
                else
                {
                    // Si la respuesta no es exitosa, maneja el error según tus necesidades
                    // Puedes lanzar una excepción, registrar el error, o tomar otra acción.
                    throw new Exception($"Error al crear el usuario. Estado de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Editar(UsuarioEdicionDTO usuarioEdicion)
        {


            try
            {

                // Construye la URL completa para la solicitud PUT
                string apiUrl = $"{_Url}EditarUsuario";

                // Serializa el objeto EdicionPruebaLabDTO a JSON
                var jsonContent = JsonConvert.SerializeObject(usuarioEdicion);

                // Configura el contenido de la solicitud
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                // Realiza la solicitud PUT
                var response = await _client.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // La solicitud fue exitosa
                    return true;
                }
                else
                {
                    // Si la respuesta no es exitosa, maneja el error según tus necesidades
                    // Puedes lanzar una excepción, registrar el error, o tomar otra acción.
                    throw new Exception($"Error al editar la prueba de laboratorio. Estado de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(string cedula)
        {



            try
            {

                var respuesta = await _client.DeleteAsync(this._Url + $"EliminarUsuario/{cedula}");

                var contenido = await respuesta.Content.ReadAsStringAsync();

                var seElimino = System.Text.Json.JsonSerializer.Deserialize<bool>(contenido);

                return seElimino;

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<List<UsuarioDTO>> ObtenerUsuarios()
        {

            try
            {
                var respuesta = await this._client.GetAsync(this._Url + "ListarUsuario");

                var contenido = await respuesta.Content.ReadAsStringAsync();

                var usuario = System.Text.Json.JsonSerializer.Deserialize<List<UsuarioDTO>>(contenido);

                return usuario;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
