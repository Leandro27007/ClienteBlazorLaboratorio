using System.ComponentModel.DataAnnotations;

namespace LaboratorioBlazorUI.Auth.AuthModels
{
    public class UsuarioRegister
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public string Telefono { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
