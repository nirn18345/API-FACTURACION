﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIPrueba.Entidades.Consultas
{
    public class Ejemplo
    {
        [Column("id_ejemplo")]
        [JsonProperty("idEjemplo")]
        public int IdEjemplo { get; set; }

        [Column("campo_uno")]
        [JsonProperty("campoUno")]
        public string CampoUno { get; set; }
        public string descripcion { get; set; }
    



}
}