using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class Detalle_factura
    {

        public int IdDetalleFActura { get; set; }

        public int Cantidad { get; set; }

        public string Descripcion { get; set; }

        public float Precio { get; set; }

        public int FacturaId { get; set; }

        public string Estado { get; set; }
    }
}
