using APIPrueba.Datos;
using APIPrueba.Entidades.Consultas;
using APIPrueba.Entidades.Operaciones;
using GDifare.Utilitario.Comun;
using GDifare.Utilitario.Log;
using GDifare.Utilitario.Servicios;
using MicroserviciosGD1.Entidades.Consultas;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace APIPrueba.Controllers
{
    [Route("gdifare/api/modulo/proyecto/v1")]
    [ApiController]
    public class SumarioVentasController : DifareApiController
    {
        #region Miembros privados del controlador

        private readonly IMapeoDatosSumarioVentas mapeoDatosSumarioVentas;

        #endregion

        #region Constructores del controlador

        public SumarioVentasController(
            IMapeoDatosSumarioVentas _mapeoDatosSumarioVentas,
            ILogHandler _logHandler)
            : base(_logHandler)
        {
            mapeoDatosSumarioVentas = _mapeoDatosSumarioVentas;
        }

        #endregion

        #region Operaciones del controlador

        // GET gdifare/api/modulo/proyecto/v1/consultar
        [HttpGet("consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<SumarioVentas>> Consultar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] ConsultarSumarioVentasQuery query)
        {
            try
            {
                // Inicialización de registro en Elasticsearch
                InitLog(CONSUMER, REFERENCE_ID, query.IdSumarioVentas.ToString());

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var SumarioVentas = new SumarioVentas();
                await Task.Factory.StartNew(() =>
                {
                    SumarioVentas = mapeoDatosSumarioVentas.Obtener(query.IdSumarioVentas);
                });


                return Ok(SumarioVentas);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // GET gdifare/api/modulo/proyecto/v1/listar
        [HttpGet("listar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedCollection<SumarioVentas>>> Listar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] ListarSumarioVentasQuery query)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var SumarioVentass = new PagedCollection<SumarioVentas>(null, 0, 0);
                await Task.Factory.StartNew(() =>
                {
                    SumarioVentass = mapeoDatosSumarioVentas.ObtenerListado(query);
                });

                return Ok(SumarioVentass);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // POST gdifare/api/modulo/proyecto/v1/grabar
        [HttpPost("grabar")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GrabarSumarioVentasResponse>> Grabar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] GrabarSumarioVentasRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
              request.IsValid();

                // Ejecución de la operación de datos
                var response = new GrabarSumarioVentasResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosSumarioVentas.Grabar(request);
                });

                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // PUT gdifare/api/modulo/proyecto/v1/modificar
        [HttpPut("modificar")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GrabarSumarioVentasResponse>> Modificar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] GrabarSumarioVentasRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new GrabarSumarioVentasResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosSumarioVentas.Grabar(request);
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