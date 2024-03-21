namespace LaboratorioBlazorUI.DTOs.ResultadoClinicoDTOs
{
    public class PdfToImageResultDTO
    {
        public List<string> urls { get; set; }
        public DateTime outputLinkValidTill { get; set; }
        public int pageCount { get; set; }
        public bool error { get; set; }
        public int status { get; set; }
        public string name { get; set; }
        public int credits { get; set; }
        public int remainingCredits { get; set; }
        public int duration { get; set; }
    }
}
