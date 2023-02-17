﻿using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Consultas
{
    public class ConsultarSumarioVentasQuery : DifareBaseRequest
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