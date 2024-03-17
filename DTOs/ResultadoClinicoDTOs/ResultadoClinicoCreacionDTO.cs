namespace DTOs.ResultadoClinicoDTOs
{
    public class ResultadoClinicoCreacionDTO
    {
        public Stream ResultadoFileStream { get; set; } = new MemoryStream();
        public string ContentType { get; set; } = "";
        public string DocumentoIdentidadDestinatario { get; set; } = "";
    
    }
}
