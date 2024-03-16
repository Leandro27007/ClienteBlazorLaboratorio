using System.ComponentModel.DataAnnotations;

namespace LaboratorioBlazorUI.Auth.AuthModels
{
    public class CambioDePasswordModel
    {
        [Required]
        public string UserName { get; set; }

        [Required (ErrorMessage ="Debes especificar la nueva contraseña")]
        [MinLength(6, ErrorMessage ="La contraseña debe contener mas de 6 caracteres")]
        public string NuevaPassword { get; set; }
    }
}
