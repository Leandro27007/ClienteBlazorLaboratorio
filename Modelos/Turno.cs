using System;
using System.Collections.Generic;
using System.Linq;
using LaboratorioBlazorUI.Modelos;

namespace LaboratorioBlazorUI.Modelos
{
    public class Turno
    {
        public string idTurno { get; set; }
        public List<PruebaLab> pruebasLab { get; set; } = new ();

    }



}
