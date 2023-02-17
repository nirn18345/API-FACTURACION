using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;
using System;

namespace APIPrueba.Entidades.Operaciones
{
    public class GrabarClienteRequest: DifareBaseRequest
    {
       
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }

       
        [JsonProperty("nombre")]
        public String Nombre { get; set; }

        
        [JsonProperty("apellido")]
        public String Apellido { get; set; }

      
        [JsonProperty("cedula")]
        public String Cedula { get; set; }

        
        [JsonProperty("correo")]
        public String Correo { get; set; }

        
        [JsonProperty("telefono")]
        public String Telefono { get; set; }

      
        [JsonProperty("direccion")]
        public String Direccion { get; set; }

       
        [JsonProperty("estado")]
        public char Estado { get; set; }

        public override void IsValid()
        {
            if (IdCliente < 0)
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            if (string.IsNullOrEmpty(Convert.ToString(IdCliente)))
            {
                throw new RequestException(MensajesSumarioVentas.CODE_ERROR_VAL_01, MensajesSumarioVentas.ERROR_VAL_01);
            }

            base.IsValid();
        }
    }
}