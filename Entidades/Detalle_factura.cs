using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class Detalle_factura
    {
        [JsonProperty("IdDetalleFActura")]
        public int IdDetalleFActura { get; set; }

        [JsonProperty("Cantidad")]
        public int Cantidad { get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("Precio")]
        public float Precio { get; set; }

        [JsonProperty("FacturaId")]
        public int FacturaId { get; set; }

        [JsonProperty("Estado")]
        public string Estado { get; set; }
    }
}
