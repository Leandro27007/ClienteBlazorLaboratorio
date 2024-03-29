﻿using DTOs;
using DTOs.ResultadoClinicoDTOs;
using LaboratorioBlazorUI.DTOs.ResultadoClinicoDTOs;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
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
                content.Add(new StreamContent(resultadoClinico.resultadoFile.OpenReadStream(maxAllowedSize: 5000000)), "file", resultadoClinico.resultadoFile.Name);

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

        public async Task<PdfToImageResultDTO> PdfToImage(IBrowserFile file)
        {
            try
            {
               

                    // Construye la URL completa para la solicitud POST
                    string uploadPdfURL = $"https://api.pdf.co/v1/file/upload";
                string pdfToImageURL = $"https://api.pdf.co/v1/pdf/convert/to/png";


                using (var client = new HttpClient())
                {

                    //PDF.CO API KEY
                    client.DefaultRequestHeaders.Add("x-api-key", "usvirux@gmail.com_jaKkt2M5voWYE50brCNVjIfCWL031EMZRxtqGeH4Ra7D0jiv55tt6m5nYYNtZbSA");


                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(file.OpenReadStream(maxAllowedSize: 5000000)), "file", file.Name);

                    // Realiza la solicitud POST
                    var response = await client.PostAsync(uploadPdfURL, content);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();

                        var result = JsonConvert.DeserializeObject<PdfCoUploadPdfResultDTO>(responseContent);


                        PdfToImageDTO pdtToImg = new();
                        pdtToImg.url = result.url;

                        // Serializa el objeto CreacionPruebaLabDTO a JSON
                        var jsonContent = JsonConvert.SerializeObject(pdtToImg);

                        // Configura el contenido de la solicitud
                        var pdfToImageContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                        var response2 = await client.PostAsync(pdfToImageURL, pdfToImageContent);


                        if (response2.IsSuccessStatusCode)
                        {
                            var response2Content = await response2.Content.ReadAsStringAsync();

                            var result2 = JsonConvert.DeserializeObject<PdfToImageResultDTO>(response2Content);

                            return result2;
                        }

                        return null;

                    }
                    else
                    {
                        // Si la respuesta no es exitosa, maneja el error según tus necesidades
                        // Puedes lanzar una excepción, registrar el error, o tomar otra acción.
                        throw new Exception($"Error al subir el resultado clinico. Estado de respuesta: {response.StatusCode}");
                    }
                }

            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
