using APIPrueba.Entidades.Consultas;
using APIPrueba.Entidades.Operaciones;
using APIPrueba.Utils;
using GDifare.Utilitario.BaseDatos;
using GDifare.Utilitario.Comun;
using MicroserviciosGD1.Entidades;
using MicroserviciosGD1.Entidades.Operaciones;
using System;
using System.Data;

namespace APIPrueba.Datos
{
    public interface IMapeoDatosDetalleFactura
    {
      //  Ejemplo Obtener(int idDetalleFactura);
        Detalle_factura ObtenerDFac(int id_detFact);
     //   PagedCollection<Ejemplo> ObtenerListado(ListarEjemplosQuery query);
        DetalleFacturaResponse GrabarDetFact(DetalleFacturaRequest request);
    }

    public class MapeoDatosDetalleFactura : MapeoDatosBase, IMapeoDatosDetalleFactura
    {
        #region Constructores de la clase

        public MapeoDatosDetalleFactura(ISqlServer _sqlServer)
            : base(_sqlServer) { }

        #endregion

        #region Implementación de la interface


        DetalleFacturaResponse IMapeoDatosDetalleFactura.GrabarDetFact(DetalleFacturaRequest request)
        {
            // Ejemplo: Se valida si existe el registro
            if (request.IdDetalleFActura > 0)
            {
                var fact = ObtenerDetalleFactura(request.IdDetalleFActura);

                // Si no existe se genera una respuesta de operación no exitosa.
                if (fact == null)
                {
                    return new DetalleFacturaResponse(
                        MensajesEjemplos.CODE_ERROR_VAL_01,
                        MensajesEjemplos.ERROR_VAL_01);
                }
            }
            // Se graba el registro
            var id_detalle = GrabarDetalleFactura(request);

            return new DetalleFacturaResponse()
            {
                IdDetalleFActura = id_detalle
            };
        }

        Detalle_factura IMapeoDatosDetalleFactura.ObtenerDFac(int idFac)
        {
            return ObtenerDetalleFactura(idFac);
        }


       /* PagedCollection<Ejemplo> IMapeoDatosDetalleFactura.ObtenerListado(ListarEjemplosQuery query)
        {
            return ObtenerListadoEjemplos(query);
        }*/

        #endregion

        #region Métodos de consulta de la clase

        private Ejemplo ObtenerEjemplo(int idEjemplo)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_ejemplo", SqlDbType.Int, idEjemplo);
            SqlServer.AddParameter("@i_descripcion", SqlDbType.Int, idEjemplo);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureExample);

            if (dataSet.Tables.Count == 0) return null;
            if (dataSet.Tables[0].Rows.Count == 0) return null;

            var ejemplo = ConvertTo<Ejemplo>(dataSet.Tables[0]);

            // Se devuelve el objeto
            return ejemplo;
        }

        private Detalle_factura ObtenerDetalleFactura(int fact)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_det_factura", SqlDbType.Int, fact);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureDetalleF);

            if (dataSet.Tables.Count == 0) return null;
            if (dataSet.Tables[0].Rows.Count == 0) return null;

            var detalle = ConvertTo<Detalle_factura>(dataSet.Tables[0]);

            // Se devuelve el objeto
            return detalle;
        }

      /*  private PagedCollection<Ejemplo> ObtenerListadoEjemplos(ListarEjemplosQuery query)
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

        private int GrabarDetalleFactura(DetalleFacturaRequest request)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, request.IdDetalleFActura.Equals(0) ? "I" : "M");
            SqlServer.AddParameter("@i_id_det_factura", SqlDbType.Int, request.IdDetalleFActura);
            SqlServer.AddParameter("@i_cantidad", SqlDbType.Int, request.Cantidad);
            SqlServer.AddParameter("@i_descripcion", SqlDbType.VarChar, request.Descripcion);
            SqlServer.AddParameter("@i_precio", SqlDbType.Decimal, request.Precio);
            SqlServer.AddParameter("@i_facturaId", SqlDbType.Int, request.FacturaId);
            SqlServer.AddParameter("@i_Estado", SqlDbType.Char, request.Estado);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureDetalleF);

            return int.Parse(dataSet.Tables[0].Rows[0]["IdDetalleFactura"].ToString());


        }

        #endregion
    }
}