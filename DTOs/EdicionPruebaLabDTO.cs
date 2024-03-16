using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class EdicionPruebaLabDTO
    {
        [Required(ErrorMessage = "El Id de la prueba de laboratorio es requerido")]
        public int idPruebaLab { get; set; }
        [Required(ErrorMessage = "El Nombre de la prueba de laboratorio es requerido")]
        public string nombrePrueba { get; set; }
        [Required(ErrorMessage = "La descripcion de la prueba de laboratorio es requerido")]
        public string descripcion { get; set; }
        public decimal? precio { get; set; }
    }
}
