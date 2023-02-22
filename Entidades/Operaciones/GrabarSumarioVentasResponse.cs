using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Servicios;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Operaciones
{
    public class GrabarSumarioVentasResponse : DifareBaseResponse
    {
        [JsonProperty("idSumarioVentas")]
        public int IdSumarioVentas { get; set; }

        internal GrabarSumarioVentasResponse()
            : base(true, ApiCodes.CODE_ERROR_API_00, ApiCodes.ERROR_API_00) { }

        internal GrabarSumarioVentasResponse(string codigo, string mensaje)
            : base(false, codigo, mensaje) { }
    }
}