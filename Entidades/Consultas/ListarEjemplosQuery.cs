﻿using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using Newtonsoft.Json;

namespace APIPrueba.Entidades.Consultas
{
    public class ListarEjemplosQuery : PagedViewRequest
    {
        [JsonProperty("campoConsulta")]
        public string CampoConsulta { get; set; }

        public override void IsValid()
        {
            /* (string.IsNullOrWhiteSpace(CampoConsulta))
            {
                throw new RequestException(MensajesEjemplos.CODE_ERROR_VAL_01, MensajesEjemplos.ERROR_VAL_01);
            }*/

            base.IsValid();
        }
    }
}