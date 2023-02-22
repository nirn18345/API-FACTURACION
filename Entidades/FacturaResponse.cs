using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class FacturaResponse: DifareBaseResponse 
    {
        [JsonProperty("IdFactura")]
        public int IdFactura { get; set; }

        [JsonProperty("IdDetalleFActura")]
        public int IdDetalleFActura { get; set; }

        [JsonProperty("procesoExitoso")]
        public bool ProcesoExitoso { get; set; }

        [JsonProperty("mensaje")]
        public string Mensaje { get; set; }

        internal FacturaResponse()
            : base(true, ApiCodes.CODE_ERROR_API_00, ApiCodes.ERROR_API_00) { }

        internal FacturaResponse(string codigo, string mensaje)
            : base(false, codigo, mensaje) { }
    }
}
