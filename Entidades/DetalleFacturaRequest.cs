using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MicroserviciosGD1.Entidades
{
    [JsonObject]
    public class DetalleFacturaRequest

    {

        public List<Detalle_factura> detalle { get; set; }

        [JsonProperty("IdDetalleFActura")]
        public int IdDetalleFActura { get; set; }

        [JsonProperty("cantidad")]
        public int Cantidad{ get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("precio")]
        public decimal Precio { get; set; }

        [JsonProperty("facturaId")]
        public int FacturaId { get; set; }
      
        public string Estado { get; set; }

       
    }
}
