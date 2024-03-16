using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class RolObtencionDTO
    {
        public int IdRol { get; set; }
        public string NombreRol { get; set; }

        public string Descripcion { get; set; }
    }
}
