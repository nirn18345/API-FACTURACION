using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;

namespace APIPrueba.Entidades.Operaciones
{
    public class GrabarEjemploRequest: DifareBaseRequest
    {
        [JsonProperty("idEjemplo")]
        public int IdEjemplo { get; set; }

        [JsonProperty("campoUno")]
        public string CampoUno { get; set; }

        [JsonProperty("descripcion")]
        public string Descripcion { get; set; }

        public override void IsValid()
        {
            if (IdEjemplo < 0)
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }

            if (string.IsNullOrEmpty(Convert.ToString(IdEjemplo)))
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}