using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class FacturaPeticion
    {

        [JsonProperty("IdFactura")] 
        public int IdFactura { get; set; }
        [JsonProperty("ClienteId")]
        public int ClienteId { get; set; }
        [JsonProperty("FechaEmision")]
        public DateTime FechaEmision { get; set; }
        [JsonProperty("Total")]
        public decimal Total { get; set; }
        [JsonProperty("Detalle")]
        public string Detalle { get; set; }
        [JsonProperty("Estado")]
        public string Estado { get; set; }

        public List<DetalleFacturaRequest> datos { get; set; }
    }
}
