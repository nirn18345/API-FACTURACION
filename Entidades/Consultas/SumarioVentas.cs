using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrueba.Entidades.Consultas
{
    public class SumarioVentas
    {
        [Column("IdSumarioVentas")]
        [JsonProperty("idSumarioVentas")]
        public int IdSumarioVentas { get; set; }


        [Column("CantidadFactura")]
        [JsonProperty("cantidadFactura")]
        public int CantidadFactura { get; set; }



        [Column("TotalFacturas")]
        [JsonProperty("totalFacturas")]
        public float TotalFacturas { get; set; }



        [Column("ClienteId")]
        [JsonProperty("clienteId")]
        public int ClienteId { get; set; }




    }
}