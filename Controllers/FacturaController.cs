using APIPrueba.Datos;
using APIPrueba.Entidades.Consultas;
using GDifare.Utilitario.Log;
using GDifare.Utilitario.Servicios;
using MicroserviciosGD1.Entidades;
using MicroserviciosGD1.Entidades.Operaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIPrueba.Controllers
{
    [Route("gdifare/api/modulo/proyecto/v1")]
    [ApiController]
    public class FacturaController :DifareApiController
    {
        #region Miembros privados del controlador

        private readonly IMapeoDatosFactura mapeoDatosFactura;
        private readonly ILogHandler logHandler;

        #endregion

        #region Constructores del controlador

        public FacturaController(
            IMapeoDatosFactura _mapeoDatosFactura,
            ILogHandler _logHandler)
            : base(_logHandler)
        {
            mapeoDatosFactura = _mapeoDatosFactura;
            logHandler = _logHandler;
        }

        #endregion

        #region Operaciones del controlador
        
                [HttpGet("consultarFactura")]
                [ProducesResponseType(StatusCodes.Status200OK)]
                [ProducesResponseType(StatusCodes.Status204NoContent)]
                [ProducesResponseType(StatusCodes.Status400BadRequest)]
                [ProducesResponseType(StatusCodes.Status500InternalServerError)]
                public async Task<ActionResult<Factura>> Consultar(
                     [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
                    [FromQuery] ConsultarFactura query)
                {
                    try
                    {
                        // Inicialización de registro en Elasticsearch
                        InitLog(CONSUMER, REFERENCE_ID, query.IdFactura.ToString());

                        // Validaciones de parámetros de entrada
                        query.IsValid();

                        // Ejecución de la operación de datos
                        var detalle = new Factura();
                        await Task.Factory.StartNew(() =>
                        {
                            detalle = mapeoDatosFactura.ObtenerFac(query.IdFactura);
                        });


                        return Ok(detalle);

                    }
                    catch (Exception e)
                    {
                        return ResponseFault(e);
                    }

                }

        /*// GET gdifare/api/modulo/proyecto/v1/listar
        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedCollection<Ejemplo>>> Listar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] ListarEjemplosQuery query)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var ejemplos = new PagedCollection<Ejemplo>(null, 0, 0);
                await Task.Factory.StartNew(() =>
                {
                    ejemplos = mapeoDatosFactura.ObtenerListado(query);
                });

                return Ok(ejemplos);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }*/

        // POST gdifare/api/modulo/proyecto/v1/grabarFactura
        [HttpPost("grabarFactura")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FacturaRequest>> GrabarFac(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] FacturaRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                //request.IsValid();

                // Ejecución de la operación de datos
                var response = new FacturaResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosFactura.GrabarFact(request);
                });
                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }


        /*// Modificar Factura
        // PUT gdifare/api/modulo/proyecto/v1/modificar
        [HttpPut("modificarFactura")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<FacturaResponse>> ModificarF(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] FacturaRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new FacturaResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosFactura.GrabarFact(request);
                });

                return Accepted(response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        */
        #endregion
    }
}