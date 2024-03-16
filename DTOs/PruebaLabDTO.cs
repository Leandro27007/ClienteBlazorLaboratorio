using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class PruebaLabDTO
    {
        public int idPruebaLab { get; set; }
        public string NombrePrueba { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }
    }
}
