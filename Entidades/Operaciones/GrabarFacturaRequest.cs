using APIPrueba.Utils;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Comun.Exceptions;
using MicroserviciosGD1.Entidades.Operaciones;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MicroserviciosGD1.Entidades.Operaciones
{
    public class GrabarFacturaRequest : DifareBaseRequest
    {
        /*
        {"Factura":{"IdFactura":0,"FechaEmision":null,"Estado":null,"Detalle":"sdfsfsd","Total":3445.0,"ClienteID":1},
        "ListaDetalles":[{"IdDetalle":null,"Descripcion":"gggg","Cantidad":54,"Precio":45.0,"Estado":null,"FacturaId":null}],
        "data":"[{\"Descripcion\":\"gggg\",\"Cantidad\":54,\"Precio\":45}]"}
         */
        [JsonProperty("Factura")]
        public FacturaPeticion Factura { get; set; }
        [JsonProperty("ListaDetalles")]
        public List<Detalle_factura> ListaDetalles { get; set; }
    }
}
