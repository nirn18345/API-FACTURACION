using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class FacturaRequest : DifareBaseRequest
    {
        [JsonProperty("IdFactura")]
        public int IdFactura {get; set;}
        [JsonProperty("ClienteId")]
        public int ClienteId { get; set; }

        [JsonProperty("FechaEmision")]
        public DateTime FechaEmision { get; set; }
        [JsonProperty("Detalle")]
        public string Detalle { get; set; }

         [JsonProperty("Total")]
        public decimal Total { get; set; }
      
        [JsonProperty("Estado")]
        public string Estado { get; set; }

        public override void IsValid()
        {
            if (IdFactura < 0)
            {
                throw new RequestException(MensajesCliente.CODE_ERROR_VAL_01, MensajesCliente.ERROR_VAL_01);
            }

            if (string.IsNullOrEmpty(Convert.ToString(IdFactura)))
            {
                throw new RequestException(MensajesCliente.CODE_ERROR_VAL_01, MensajesCliente.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}
