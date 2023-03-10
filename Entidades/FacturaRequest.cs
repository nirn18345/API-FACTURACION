using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using MicroserviciosGD1.Entidades.Operaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MicroserviciosGD1.Entidades
{
    [JsonObject]
    public class FacturaRequest : DifareBaseRequest
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
