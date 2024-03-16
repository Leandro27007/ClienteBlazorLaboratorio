using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ReporteDTO
    {
        public DateTime fechaDeGeneracion { get; set; }
        public List<ReciboDTO> recibos { get; set; }
        public decimal? totalVenta { get; set; }
    }
}