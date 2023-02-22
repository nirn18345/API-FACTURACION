using APIPrueba.Utils;
using GDifare.Utilitario.BaseDatos;
using GDifare.Utilitario.Comun;
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
         //PagedCollection<Factura> ObtenerListado(ListarFacturaQuery query);

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
            // SumarioVentas: Se valida si existe el registro
            if (request.IdFactura > 0)
            {
                var factura = ObtenerFactura(request.IdFactura);

                // Si no existe se genera una respuesta de operación no exitosa.
                if (factura == null)
                {
                    return new FacturaResponse(
                        MensajesSumarioVentas.CODE_ERROR_VAL_01,
                        MensajesSumarioVentas.ERROR_VAL_01);
                }
            }

            GrabarFactura(request);
            return new FacturaResponse();

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

            DateTime fechaActual = DateTime.Now;



            // Se establecen los parámetros del procedimiento a ejecutar
                SqlServer.AddParameter("@i_accion", SqlDbType.Char, request.IdFactura.Equals(0) ? "I" : "M");
                SqlServer.AddParameter("@i_id_factura", SqlDbType.Int, request.IdFactura);
                SqlServer.AddParameter("@i_clienteId", SqlDbType.Int, request.ClienteId);
                SqlServer.AddParameter("@i_fecha_emi", SqlDbType.DateTime, fechaActual);
                SqlServer.AddParameter("@i_detalle", SqlDbType.VarChar, request.Detalle);
                SqlServer.AddParameter("@i_total", SqlDbType.Decimal, request.Total);
                SqlServer.AddParameter("@i_tipo_registro", SqlDbType.Char, 'F');



                // Se realiza la consulta a la base de datos
                var dataSet = SqlServer.ExecuteProcedure(Environment.GetEnvironmentVariable(StringHandler.Database), StringHandler.ProcedureFactura);

            if (dataSet.Tables.Count > 0)
            {
                var responseRow = dataSet.Tables[0].Rows[0];
                var idCApturado=request.IdFactura = Int32.Parse(responseRow["IdFactura"].ToString());

                GrabarDetalleFactura(request.datos, idCApturado);


            }
            
            
            //request.IdFactura = int.Parse(dataSet.Tables[0].Rows[0]["IdFactura"].ToString());
            

        }


        [ExcludeFromCodeCoverage]
        private void GrabarDetalleFactura(List<DetalleFacturaRequest> request, int IdFactura)
        {

            foreach (DetalleFacturaRequest d in request) {

                SqlServer.AddParameter("@i_accion", SqlDbType.Char, d.IdDetalleFActura.Equals(0) ? "I" : "M");
                SqlServer.AddParameter("@i_id_det_factura", SqlDbType.Int, d.IdDetalleFActura);
                SqlServer.AddParameter("@i_cantidad", SqlDbType.Int, d.Cantidad);
                SqlServer.AddParameter("@i_descripcion", SqlDbType.VarChar, d.Descripcion);
                SqlServer.AddParameter("@i_precio", SqlDbType.Decimal, d.Precio);
                SqlServer.AddParameter("@i_facturaId", SqlDbType.Int, IdFactura);
                SqlServer.AddParameter("@i_tipo_registro", SqlDbType.Char, 'D');

                // Se realiza la consulta a la base de datos
                var dataSet = SqlServer.ExecuteProcedure(Environment.GetEnvironmentVariable(StringHandler.Database), StringHandler.ProcedureFactura);

                if (dataSet.Tables.Count > 0)
                {
                    var responseRow = dataSet.Tables[0].Rows[0];
                    d.IdDetalleFActura = Int32.Parse(responseRow["IdDetalleFActura"].ToString());
                }
            }

        }

        #endregion
    }
}
