using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReciboBusquedaCancelacionDTO
    {
        [StringLength(8, ErrorMessage = "El Numero de Recibo debe tener un máximo de 8 caracteres.")]
        [Required(ErrorMessage = "El Numero de Recibo es requerido")]
        [RegularExpression(@"[a-zA-Z0-9]+", ErrorMessage = "El Numero de Recibo solo debe contener letras y números.")]
        public string NumeroRecibo { get; set; }
    }
}
