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
    public class ConsultarEjemploQuery : DifareBaseRequest
    {
        [JsonProperty("IdFactura")]
        public int IdFactura { get; set; }

        public override void IsValid()
        {
            if (IdFactura < 0)
            {
                throw new RequestException(StringHandler.CODE_ERROR_VAL_01, StringHandler.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}
