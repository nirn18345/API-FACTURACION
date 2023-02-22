using APIPrueba.Entidades.Consultas;
using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace APIPrueba.Entidades.Operaciones
{
    public class GrabarSumarioVentasRequest: DifareBaseRequest
    {
        public List<SumarioVentas> sumario { get; set; }

        [JsonProperty("idSumarioVentas")]
        public int IdSumarioVentas { get; set; }


        
        [JsonProperty("cantidadFactura")]
        public int CantidadFactura { get; set; }



        [JsonProperty("totalFacturas")]
        public float TotalFacturas { get; set; }



       
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }

        public override void IsValid()
        {
            if (IdSumarioVentas < 0)
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            if (string.IsNullOrEmpty(Convert.ToString(IdSumarioVentas)))
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}