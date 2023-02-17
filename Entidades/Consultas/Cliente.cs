using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MicroserviciosGD1.Entidades.Consultas
{
    public class Cliente
    {
        
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
       
        [Column("Nombre")]
        [JsonProperty("nombre")]
        public String Nombre { get; set; }

        [Column("Apellido")]
        [JsonProperty("apellido")]
        public String Apellido { get; set; }
        
        [Column("Cedula")]
        [JsonProperty("cedula")]
        public String Cedula { get; set; }

        [Column("Correo")]
        [JsonProperty("correo")]
        public String Correo { get; set; }

        [Column("Telefono")]
        [JsonProperty("telefono")]
        public String Telefono { get; set; }

        [Column("Direccion")]
        [JsonProperty("direccion")]
        public String Direccion { get; set; }

        [Column("Estado")]
        [JsonProperty("estado")]
        public char Estado { get; set; }




    }
}
