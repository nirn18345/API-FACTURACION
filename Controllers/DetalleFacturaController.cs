using APIPrueba.Datos;
using APIPrueba.Entidades.Consultas;
using APIPrueba.Entidades.Operaciones;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Log;
using GDifare.Utilitario.Servicios;
using MicroserviciosGD1.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIPrueba.Controllers
{
    [Route("gdifare/api/modulo/proyecto/v1")]
    [ApiController]
    public class DetalleFacturaController : DifareApiController
    {
        #region Miembros privados del controlador

        private readonly IMapeoDatosDetalleFactura mapeoDatosDetalleFact;

        #endregion

        #region Constructores del controlador

        public DetalleFacturaController(
            IMapeoDatosDetalleFactura _mapeoDetalleFactura,
            ILogHandler _logHandler)
            : base(_logHandler)
        {
            mapeoDatosDetalleFact = _mapeoDetalleFactura;
        }

        #endregion

        #region Operaciones del controlador

       /* // GET gdifare/api/modulo/proyecto/v1/consultar
        [HttpGet("consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Ejemplo>> Consultar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] Entidades.Consultas.ConsultarEjemploQuery query)
        {
            try
            {
                // Inicialización de registro en Elasticsearch
                InitLog(CONSUMER, REFERENCE_ID, query.IdEjemplo.ToString());

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var ejemplo = new Ejemplo();
                await Task.Factory.StartNew(() =>
                {
                    ejemplo = mapeoDatosDetalleFact.Obtener(query.IdEjemplo);
                });


                return Ok(ejemplo);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }*/

     /*   // GET gdifare/api/modulo/proyecto/v1/listar
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
                    ejemplos = mapeoDatosDetalleFact.ObtenerListado(query);
                });

                return Ok(ejemplos);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }*/

        // POST gdifare/api/modulo/proyecto/v1/grabarFactura
        [HttpPost("grabarDetalleFactura")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DetalleFacturaResponse>> GrabarDetFac(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] DetalleFacturaRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new DetalleFacturaResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosDetalleFact.GrabarDetFact(request);
                });

                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }


        // Modificar Factura
        // PUT gdifare/api/modulo/proyecto/v1/modificar
        [HttpPut("modificarDetalleFactura")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<DetalleFacturaResponse>> ModificarDF(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] DetalleFacturaRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new DetalleFacturaResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosDetalleFact.GrabarDetFact(request);
                });

                return Accepted(response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }


        #endregion
    }
}