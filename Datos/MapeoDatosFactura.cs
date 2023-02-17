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
    public interface IMapeoDatosFactura
    {
      //  Ejemplo Obtener(int idEjemplo);
        Factura ObtenerFac(int idFactura);
     //   PagedCollection<Ejemplo> ObtenerListado(ListarEjemplosQuery query);
        FacturaResponse GrabarFact(FacturaRequest request);
    }

    public class MapeoDatosFactura : MapeoDatosBase, IMapeoDatosFactura
    {
        #region Constructores de la clase

        public MapeoDatosFactura(ISqlServer _sqlServer)
            : base(_sqlServer) { }

        #endregion

        #region Implementación de la interface


        FacturaResponse IMapeoDatosFactura.GrabarFact(FacturaRequest request)
        {
            // Ejemplo: Se valida si existe el registro
            if (request.IdFactura > 0)
            {
                var fact = ObtenerFactura(request.IdFactura);

                // Si no existe se genera una respuesta de operación no exitosa.
                if (fact == null)
                {
                    return new FacturaResponse(
                        MensajesCliente.CODE_ERROR_VAL_01,
                        MensajesCliente.ERROR_VAL_01);
                }
            }
            // Se graba el registro
            var id_fac = GrabarFactura(request);

            return new FacturaResponse()
            {
                IdFactura = id_fac
            };
        }

        Factura IMapeoDatosFactura.ObtenerFac(int idFac)
        {
            return ObtenerFactura(idFac);
        }


       /* PagedCollection<Ejemplo> IMapeoDatosFactura.ObtenerListado(ListarEjemplosQuery query)
        {
            return ObtenerListadoEjemplos(query);
        }*/

        #endregion

        #region Métodos de consulta de la clase

      /*  private Ejemplo ObtenerEjemplo(int idEjemplo)
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
      */
        private Factura ObtenerFactura(int fact)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_factura", SqlDbType.Int, fact);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureFactura);

            if (dataSet.Tables.Count == 0) return null;
            if (dataSet.Tables[0].Rows.Count == 0) return null;

            var facture = ConvertTo<Factura>(dataSet.Tables[0]);

            // Se devuelve el objeto
            return facture;
        }

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

        private int GrabarFactura(FacturaRequest request)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, request.IdFactura.Equals(0) ? "I" : "M");
            SqlServer.AddParameter("@i_id_factura", SqlDbType.Int, request.IdFactura);
            SqlServer.AddParameter("@i_clienteId", SqlDbType.Int, request.ClienteId);
            SqlServer.AddParameter("@i_fecha_emi", SqlDbType.DateTime, request.FechaEmision);
            SqlServer.AddParameter("@i_detalle", SqlDbType.VarChar, request.Detalle);
            SqlServer.AddParameter("@i_total", SqlDbType.Decimal, request.Total);
            SqlServer.AddParameter("@i_estado", SqlDbType.Char, request.Estado);
            

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure(StringHandler.ProcedureFactura);

            return int.Parse(dataSet.Tables[0].Rows[0]["IdFactura"].ToString());


        }

        #endregion
    }
}