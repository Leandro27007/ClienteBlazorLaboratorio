using System.ComponentModel.DataAnnotations;

namespace LaboratorioBlazorUI.Auth.AuthModels
{
    public class UsuarioLogin
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
