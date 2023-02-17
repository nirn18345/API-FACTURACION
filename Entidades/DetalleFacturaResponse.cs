using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Servicios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades
{
    public class DetalleFacturaResponse: DifareBaseResponse
    {
        [JsonProperty("IdDetalleFActura")]
        public int IdDetalleFActura { get; set; }

        internal DetalleFacturaResponse()
            : base(true, ApiCodes.CODE_ERROR_API_00, ApiCodes.ERROR_API_00) { }

        internal DetalleFacturaResponse(string codigo, string mensaje)
            : base(false, codigo, mensaje) { }
    }
}
