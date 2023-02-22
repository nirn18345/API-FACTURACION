using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades.Consultas
{
    public class ConsultarSumarioVentasQuery: DifareBaseRequest
    {

        [JsonProperty("idSumarioVentas")]
        public int IdSumarioVentas { get; set; }

        public override void IsValid()
        {
            if (IdSumarioVentas <= 0)
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}
