using Microsoft.AspNetCore.Components.Forms;

namespace DTOs.ResultadoClinicoDTOs
{
    public class ResultadoClinicoCreacionDTO
    {
        public IBrowserFile resultadoFile { get; set; }
        public string ContentType { get; set; } = "";
        public string DocumentoIdentidadDestinatario { get; set; } = "";
    
    }
}
