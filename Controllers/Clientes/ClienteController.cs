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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clientes.Controllers
{
    [Route("gdifare/api/modulo/proyecto/v1/cliente")]
    [ApiController]
    public class ClienteController : DifareApiController
    {
        #region Miembros privados del controlador

        private readonly IMapeoDatosCliente mapeoDatosCliente;

        #endregion

        #region Constructores del controlador

        public ClienteController(
            IMapeoDatosCliente _mapeoDatosCliente,
            ILogHandler _logHandler)
            : base(_logHandler)
        {
            mapeoDatosCliente = _mapeoDatosCliente;
        }

        #endregion

        #region Operaciones del controlador

        // GET gdifare/api/modulo/proyecto/v1/consultar
        [HttpGet("consultar")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Cliente>> Consultar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] ConsultarClienteQuery query)
        {
            try
            {
                // Inicialización de registro en Elasticsearch
                InitLog(CONSUMER, REFERENCE_ID, query.IdCliente.ToString());

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var cliente = new Cliente();
                await Task.Factory.StartNew(() =>
                {
                    cliente = mapeoDatosCliente.Obtener(query.IdCliente);
                });


                return Ok(cliente);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // GET gdifare/api/modulo/proyecto/v1/listar
        [HttpGet("listarCliente")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<PagedCollection<Cliente>>> Listar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromQuery] ListarClienteQuery query)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                query.IsValid();

                // Ejecución de la operación de datos
                var Clientes = new PagedCollection<Cliente>(null, 0, 0);
                await Task.Factory.StartNew(() =>
                {
                    Clientes = mapeoDatosCliente.ObtenerListado(query);
                });

                return Ok(Clientes);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // POST gdifare/api/modulo/proyecto/v1/grabar
        [HttpPost("grabarCliente")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GrabarClienteResponse>> Grabar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] GrabarClienteRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new GrabarClienteResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosCliente.Grabar(request);
                });

                return Created(string.Empty, response);
            }
            catch (Exception e)
            {
                return ResponseFault(e);
            }
        }

        // PUT gdifare/api/modulo/proyecto/v1/modificar
        [HttpPut("modificarCliente")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<GrabarClienteResponse>> Modificar(
            [FromHeader] string REFERENCE_ID, [FromHeader] string CONSUMER,
            [FromBody] GrabarClienteRequest request)
        {
            try
            {
                // Inicialización de registro en ElasticSearch
                InitLog(CONSUMER, REFERENCE_ID, string.Empty);

                // Validaciones de parámetros de entrada
                request.IsValid();

                // Ejecución de la operación de datos
                var response = new GrabarClienteResponse();
                await Task.Factory.StartNew(() =>
                {
                    response = mapeoDatosCliente.Grabar(request);
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
