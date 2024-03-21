namespace LaboratorioBlazorUI.DTOs.ResultadoClinicoDTOs
{
    public class PdfToImageDTO
    {
        public string url { get; set; }
        public bool inline { get; set; } = true;
        public string pages { get; set; } = "0-";
        public bool async { get; set; } = false;
    }
}
