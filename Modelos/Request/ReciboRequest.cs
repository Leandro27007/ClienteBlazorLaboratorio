using System.ComponentModel.DataAnnotations;

namespace LaboratorioBlazorUI.Modelos.Request
{
    public class ReciboRequest
    {

        public string idCajero { get; set; }
        [Required (ErrorMessage ="El nombre del cliente es requerido")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El Nombre solo debe contener letras y espacios en blanco.")]
        public string nombreCliente { get; set; }
        [Required(ErrorMessage = "El nombre del cliente es requerido")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "El Nombre solo debe contener letras y espacios en blanco.")]
        public string apellidoCliente { get; set; }
        [RegularExpression(@"\d+", ErrorMessage = "El telefono solo debe contener dígitos.")]
        public string telefono { get; set; }
        [EmailAddress(ErrorMessage ="El correo no parece ser correcto.")]
        public string email { get; set; }
        [RegularExpression(@"^[a-zA-Z0-9]*$", ErrorMessage = "Solo se permiten letras y numeros.")]
        public string cedula { get; set; }
        public List<PruebaLab> pruebas { get; set; }
    }
}
