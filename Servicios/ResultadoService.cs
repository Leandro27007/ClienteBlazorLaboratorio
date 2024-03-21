using DTOs;
using DTOs.ResultadoClinicoDTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text;

namespace LaboratorioBlazorUI.Servicios
{
    public class ResultadoService
    {


        private HttpClient _client;
        private readonly string _Url = ENV._Url + "Resultado/";
        private readonly AuthenticationStateProvider _authenticationStateProvider;
        public ResultadoService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            this._authenticationStateProvider = authenticationStateProvider;
            this._client = client;

        }


        public async Task<DestinatarioDTO> BuscarDestinatario(string documentoIdentidad)
        {

            try
            {
                documentoIdentidad = documentoIdentidad.Replace("-", "");

                // Construye la URL completa para la solicitud GET
                string apiUrl = $"{_Url}BuscarDestinario {documentoIdentidad}";

                // Realiza la solicitud GET
                var response = await _client.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var destinatario = JsonConvert.DeserializeObject<DestinatarioDTO>(content);
                    return destinatario;
                }
                else
                {

                    throw new Exception($"No se encontro un cliente o tutor con este documento. Estado de respuesta: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<ResultadoDTO> SubirResultado(ResultadoClinicoCreacionDTO resultadoClinico)
        {
            try
            {
                // Construye la URL completa para la solicitud POST
                string apiUrl = $"{_Url}SubirResultado";

                // Serializa el objeto CreacionPruebaLabDTO a JSON
                //  var jsonContent = JsonConvert.SerializeObject(usuarioCreacion);

                // Configura el contenido de la solicitud
                // var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var content = new MultipartFormDataContent();
                content.Add(new StreamContent(resultadoClinico.resultadoFile.OpenReadStream(maxAllowedSize:5000000)), "file", resultadoClinico.resultadoFile.Name);

                content.Add(new StringContent("contenido"), "ContentType");
                // Realiza la solicitud POST
                var response = await _client.PostAsync(apiUrl + "?documentoIdentidadDestinatario=" + resultadoClinico.DocumentoIdentidadDestinatario, content);

                if (response.IsSuccessStatusCode)
                {
                    // Lee el contenido de la respuesta y deserialízalo en un objeto PruebaLab
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<ResultadoDTO>(responseContent);
                    return result;
                }
                else
                {
                    // Si la respuesta no es exitosa, maneja el error según tus necesidades
                    // Puedes lanzar una excepción, registrar el error, o tomar otra acción.
                    throw new Exception($"Error al subir el resultado clinico. Estado de respuesta: {response.StatusCode}");
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
