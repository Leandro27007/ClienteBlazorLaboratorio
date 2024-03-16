using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaboratorioBlazorUI.Modelos.Response
{
    public class ReciboResponse
    {

            public int idRecibo { get; set; }
            public string nombreCliente { get; set; }
            public string nombreCajero { get; set; }
            public string estado { get; set; }
            public List<PruebaLab> pruebas { get; set; }
            public float total { get; set; }
 
    }
}
