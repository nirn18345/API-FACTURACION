using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades.Operaciones
{
    public class Factura
    {
        public int IdFactura {get; set;}

        public DateTime FechaEmision { get; set; }

        public decimal Total { get; set; }

        public string Detalle { get; set; }
        public int ClienteId { get; set; }
       
        public string Estado { get; set; }
     }
}
