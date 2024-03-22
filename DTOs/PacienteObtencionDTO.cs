namespace LaboratorioBlazorUI.DTOs
{
    public class PacienteObtencionDTO
    {

        public int PacienteId { get; set; }

        public string Nombre { get; set; } = "";

        public string Apellido { get; set; } = "";

        public string? Telefono { get; set; }

        public string? Documento { get; set; }

        public string? Password { get; set; }

        public string? Email { get; set; }



    }
}
