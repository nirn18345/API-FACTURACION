using APIPrueba.Utils;
using GDifare.Utilitario.BaseDatos;
using MicroserviciosGD1.Entidades;
using MicroserviciosGD1.Entidades.Operaciones;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;

namespace APIPrueba.Datos
{
    public interface IMapeoDatosFactura
    {
      //  Ejemplo Obtener(int idEjemplo);
       Factura ObtenerFac(int idFactura);
        //   PagedCollection<Ejemplo> ObtenerListado(ListarEjemplosQuery query);

       // List<ConsultarFactura> ObtenerDet(int idDewtalle);
        FacturaResponse GrabarFact(FacturaRequest request);
    }

    public class MapeoDatosFactura : MapeoDatosBase, IMapeoDatosFactura
    {
        #region Constructores de la clase

        public MapeoDatosFactura(ISqlServer _sqlServer)
            : base(_sqlServer) { }

        #endregion

        #region Implementación de la interface

        Factura IMapeoDatosFactura.ObtenerFac(int idDetalle)
        {
            return ObtenerFactura(idDetalle);
        }
      //   [ExcludeFromCodeCoverage]
           private Factura ObtenerFactura(int id)
             {

            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_factura", SqlDbType.Int, id);

               var dataSet = SqlServer.ExecuteProcedure(Environment.GetEnvironmentVariable(StringHandler.Database), StringHandler.ProcedureFactura);

               if (dataSet.Tables.Count == 0) return null;
               if (dataSet.Tables[0].Rows.Count == 0) return null;
                  var  retorno = ConvertTo<Factura>(dataSet.Tables[0]);

               return retorno;
             }


        [ExcludeFromCodeCoverage]
        FacturaResponse IMapeoDatosFactura.GrabarFact(FacturaRequest request)
        {
            // Ejemplo: Se valida si existe el registro
            var response = new FacturaResponse() {
                ProcesoExitoso = false,
                Mensaje = StringHandler.CODE_ERROR_VAL_01,
                IdFactura = 0,
            };
            
                //se graba la factura
                GrabarFactura(request);

                IList<DetalleFacturaRequest> listDetalle = new List<DetalleFacturaRequest>();
                //  var listDetalle = request.DetalleFactura;
                DetalleFacturaRequest det;
                if (request.Accion == "I")
                {
                    foreach (var recorre in request.DetalleFactura)
                    {
                        det = new DetalleFacturaRequest
                        {
                            IdDetalleFActura = recorre.IdDetalleFActura,
                            Cantidad = recorre.Cantidad,
                            Descripcion = recorre.Descripcion,
                            Precio = recorre.Precio,
                            FacturaId = recorre.FacturaId,
                            Estado = recorre.Estado
                        };
                        listDetalle.Add(det);

                        GrabarDetalleFactura(request, recorre);
                    }

                }
                else if (request.Accion == "M")
                {
                    foreach (var actualiza in request.DetalleFactura)
                    {
                        det = new DetalleFacturaRequest
                        {
                            IdDetalleFActura = actualiza.IdDetalleFActura,
                            Cantidad = actualiza.Cantidad,
                            Descripcion = actualiza.Descripcion,
                            Precio = actualiza.Precio,
                            Estado = actualiza.Estado
                        };
                        listDetalle.Add(det);
                        GrabarDetalleFactura(request, actualiza);
                    }
                }

                // Se setea el objeto de respuesta
                response.ProcesoExitoso = true;
                response.Mensaje = StringHandler.OK;
                response.IdFactura = request.IdFactura;
                return response;
           }


       /* PagedCollection<Ejemplo> IMapeoDatosFactura.ObtenerListado(ListarEjemplosQuery query)
        {
            return ObtenerListadoEjemplos(query);
        }*/

        #endregion

        #region Métodos de consulta de la clase


       /* private PagedCollection<Ejemplo> ObtenerListadoEjemplos(ListarEjemplosQuery query)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "G");
            SqlServer.AddParameter("@i_campo_uno", SqlDbType.VarChar, query.CampoConsulta);
            SqlServer.AddParameter("@i_descripcion", SqlDbType.VarChar, query.CampoConsulta);
            SqlServer.AddParameter("@i_offset", SqlDbType.Int, query.Offset);
            SqlServer.AddParameter("@i_limit", SqlDbType.Int, query.Limit);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureExample);

            // Se genera la consulta paginada
            var totalRegistros = Convert.ToInt32(dataSet.Tables[0].Rows[0]["total_registros"]);
            var ejemplos = ConvertToList<Ejemplo>(dataSet.Tables[1]);

            // Se devuelve el objeto
            return new PagedCollection<Ejemplo>(ejemplos, totalRegistros, query.Limit);
        }
       */
        #endregion

        #region Métodos de operaciones de la clase

        private void GrabarFactura(FacturaRequest request)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, request.IdFactura.Equals(0) ? "I" : "M");
            SqlServer.AddParameter("@i_id_factura", SqlDbType.Int, request.IdFactura);
            SqlServer.AddParameter("@i_clienteId", SqlDbType.Int, request.ClienteId);
            SqlServer.AddParameter("@i_fecha_emi", SqlDbType.DateTime, request.FechaEmision);
            SqlServer.AddParameter("@i_detalle", SqlDbType.VarChar, request.Detalle);
            SqlServer.AddParameter("@i_total", SqlDbType.Decimal, request.Total);
            SqlServer.AddParameter("@i_tipo_registro", SqlDbType.Char, 'F');
          
            

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(Environment.GetEnvironmentVariable(StringHandler.Database),StringHandler.ProcedureFactura);

            request.IdFactura = int.Parse(dataSet.Tables[0].Rows[0]["IdFactura"].ToString());


        }


        [ExcludeFromCodeCoverage]
        private void GrabarDetalleFactura(FacturaRequest request, DetalleFacturaRequest detalles)
        {
            
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, detalles.IdDetalleFActura.Equals(0) ? "I" : "M");
            SqlServer.AddParameter("@i_id_det_factura", SqlDbType.Int, detalles.IdDetalleFActura);
            SqlServer.AddParameter("@i_cantidad", SqlDbType.Int, detalles.Cantidad);
            SqlServer.AddParameter("@i_descripcion", SqlDbType.VarChar, detalles.Descripcion);
            SqlServer.AddParameter("@i_precio", SqlDbType.Decimal, detalles.Precio);
            SqlServer.AddParameter("@i_facturaId", SqlDbType.Int, detalles.FacturaId);
            SqlServer.AddParameter("@i_tipo_registro", SqlDbType.Char, 'D');
            
            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(Environment.GetEnvironmentVariable(StringHandler.Database), StringHandler.ProcedureFactura);
            
            if (dataSet.Tables.Count > 0)
            {
                var responseRow = dataSet.Tables[0].Rows[0];
                detalles.IdDetalleFActura = Int32.Parse(responseRow["IdDetalleFActura"].ToString());
            }

        }

        #endregion
    }
}
