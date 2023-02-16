using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Consultas
{
    public class ConsultarEjemploQuery : DifareBaseRequest
    {
        [JsonProperty("idEjemplo")]
        public int IdEjemplo { get; set; }

        public override void IsValid()
        {
            if (IdEjemplo <= 0)
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}