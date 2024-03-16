using System.ComponentModel.DataAnnotations;

namespace DTOs
{
    public class UsuarioCreacionDTO
    {
        [Required(ErrorMessage ="La cedula es requerida")]
        public string cedula { get; set; }
        [Required(ErrorMessage = "El nombre es requerido")]
        public string nombre { get; set; }
        [Required(ErrorMessage = "El apellido es requerido")]
        public string apellido { get; set; }
        [Required(ErrorMessage = "el username es requerido")]
        public string username { get; set; }
        [Required(ErrorMessage = "la contrasena es requerida")]
        public string password { get; set; }       
        [Required(ErrorMessage = "El rol es requerido")]
        public int idRol { get; set; }
        public string telefono { get; set; }
        public string? email { get; set; }
        public string? estado { get; set; }

    }
}
