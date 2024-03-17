using System.ComponentModel.DataAnnotations;

namespace DTOs.ResultadoClinicoDTOs
{
    public class DestinatarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
        [Required(ErrorMessage = "Se requiere un cliente como destino")]
        public string Documento { get; set; } = "";
        
    }
}
