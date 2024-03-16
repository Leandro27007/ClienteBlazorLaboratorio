using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PacienteDTO
    {
        public int IdRecibo { get; set; }
        public string NombreCliente { get; set; } = null!;
        public string ApellidoCliente { get; set; } = null!;
        public string Estado { get; set; } = null!;
        public List<PruebaPacienteDTO>? Pruebas { get; set; }


    }
}
