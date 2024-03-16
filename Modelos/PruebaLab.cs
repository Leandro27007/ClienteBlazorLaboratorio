using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioBlazorUI.Modelos
{
    public class PruebaLab
    {
        public int idPruebaLab { get; set; }
        public string nombrePrueba { get; set; }
        public string descripcion { get; set; }
        public decimal? precio { get; set; }
        public bool isChecked { get; set; } = false;
    }
}
