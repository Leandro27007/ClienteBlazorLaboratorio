using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class TurnoDTO
    {
        public string IdTurno { get; set; }
        public List<PruebaLabTurnoDTO> PruebasLab { get; set; }
    }
}
