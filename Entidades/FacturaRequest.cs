using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MicroserviciosGD1.Entidades
{
    [JsonObject]
    public class FacturaRequest : DifareBaseRequest
    {
       
        [JsonProperty("IdFactura")]
        public int IdFactura {get; set;}
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("fecha_emision")]
        public DateTime FechaEmision { get; set; }
        [JsonProperty("detalle")]
        public string Detalle { get; set; }

         [JsonProperty("total")]
        public decimal Total { get; set; }
      
        [JsonProperty("estado")]
        public string Estado { get; set; }
      
        public string Accion { get; set; }

        [JsonProperty("datos")]
        public IList<DetalleFacturaRequest> DetalleFactura { get; set; }

       /* public void resultado()
        {
            decimal resultado = (ob.Cantidad * ob.Precio);
        }*/
    }
}
