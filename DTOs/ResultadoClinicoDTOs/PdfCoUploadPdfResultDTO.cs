namespace LaboratorioBlazorUI.DTOs.ResultadoClinicoDTOs
{
    public class PdfCoUploadPdfResultDTO
    {
        public string url { get; set; }
        public DateTime outputLinkValidTill { get; set; }
        public bool error { get; set; }
        public int status { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public int remainingCredits { get; set; }
        public int duration { get; set; }
    }
}
