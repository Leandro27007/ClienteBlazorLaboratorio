using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioBlazorUI.Modelos.Request
{
    public class ReembolsoRequest
    {
        public string IdRecibo { get; set; }
        [Required(ErrorMessage = "Debe dejar una nota que explique por que se cancelo este recibo.")]
        public string notaModificacion { get; set; }
    }
}
