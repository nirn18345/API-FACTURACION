using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Servicios;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Operaciones
{
    public class GrabarClienteResponse : DifareBaseResponse
    {
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }

        internal GrabarClienteResponse()
            : base(true, ApiCodes.CODE_ERROR_API_00, ApiCodes.ERROR_API_00) { }

        internal GrabarClienteResponse(string codigo, string mensaje)
            : base(false, codigo, mensaje) { }
    }
}