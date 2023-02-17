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
    public class DetalleFacturaRequest:DifareBaseRequest
    {
        [JsonProperty("IdDetalleFActura")]
        public int IdDetalleFActura { get; set; }

        [JsonProperty("Cantidad")]
        public int Cantidad{ get; set; }

        [JsonProperty("Descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("Precio")]
        public decimal Precio { get; set; }

        [JsonProperty("FacturaId")]
        public int FacturaId { get; set; }
      
        public string Estado { get; set; }

      /*  public override void IsValid()
        {
            if (IdDetalleFActura < 0)
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }

            if (string.IsNullOrEmpty(Convert.ToString(IdDetalleFActura)))
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }

            base.IsValid();
        }*/
    }
}
