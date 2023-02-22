using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Consultas
{
    public class ConsultarFactura : DifareBaseRequest
    {
        [JsonProperty("IdFactura")]
        public int IdFactura { get; set; }

        /*public override void IsValid()
        {
            if (IdFactura < 0)
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            base.IsValid();
        }*/
    }
}