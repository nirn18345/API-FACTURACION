using APIPrueba.Entidades.Consultas;
using APIPrueba.Entidades.Operaciones;
using APIPrueba.Utils;
using GDifare.Utilitario.BaseDatos;
using GDifare.Utilitario.Comun;
using System;
using System.Data;

namespace APIPrueba.Datos
{
    public interface IMapeoDatosSumarioVentas
    {
        SumarioVentas Obtener(int idSumarioVentas);
        PagedCollection<SumarioVentas> ObtenerListado(ListarSumarioVentasQuery query);
        GrabarSumarioVentasResponse Grabar(GrabarSumarioVentasRequest request);
        
    }

    public class MapeoDatosSumarioVentas : MapeoDatosBase, IMapeoDatosSumarioVentas
    {
        #region Constructores de la clase

        public MapeoDatosSumarioVentas(ISqlServer _sqlServer)
            : base(_sqlServer) { }

        #endregion

        #region Implementación de la interface

        GrabarSumarioVentasResponse IMapeoDatosSumarioVentas.Grabar(GrabarSumarioVentasRequest request)
        {
            
            // SumarioVentas: Se valida si existe el registro
            if (request.IdSumarioVentas > 0)
            {
                var SumarioVentas = ObtenerSumarioVentas(request.IdSumarioVentas);

                // Si no existe se genera una respuesta de operación no exitosa.
                if (SumarioVentas == null)
                {
                    return new GrabarSumarioVentasResponse(
                        MensajesSumarioVentas.CODE_ERROR_VAL_01,
                        MensajesSumarioVentas.ERROR_VAL_01);
                }
            }
            
            // Se graba el registro
            foreach(SumarioVentas s in request.sumario)
            {
                var idSumarioVentas = GrabarSumarioVentas(request);
            }
            
            return new GrabarSumarioVentasResponse();
        }

        SumarioVentas IMapeoDatosSumarioVentas.Obtener(int idSumarioVentas)
        {
            return ObtenerSumarioVentas(idSumarioVentas);
        }

        PagedCollection<SumarioVentas> IMapeoDatosSumarioVentas.ObtenerListado(ListarSumarioVentasQuery query)
        {
            return ObtenerListadoSumarioVentass(query);
        }

        #endregion

        #region Métodos de consulta de la clase

        private SumarioVentas ObtenerSumarioVentas(int idSumarioVentas)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_sumario_venta", SqlDbType.Int, idSumarioVentas);
            

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure("pr_sumarioVentas");

            if (dataSet.Tables.Count == 0) return null;
            if (dataSet.Tables[0].Rows.Count == 0) return null;

            var SumarioVentas = ConvertTo<SumarioVentas>(dataSet.Tables[0]);

            // Se devuelve el objeto
            return SumarioVentas;
        }

        private PagedCollection<SumarioVentas> ObtenerListadoSumarioVentass(ListarSumarioVentasQuery query)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "G");
            SqlServer.AddParameter("@i_offset", SqlDbType.Int, query.Offset);
            SqlServer.AddParameter("@i_limit", SqlDbType.Int, query.Limit);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure("pr_sumarioVentas");

            // Se genera la consulta paginada
            var totalRegistros = Convert.ToInt32(dataSet.Tables[0].Rows[0]["total_registros"]);
            var SumarioVentass = ConvertToList<SumarioVentas>(dataSet.Tables[1]);

            // Se devuelve el objeto
            return new PagedCollection<SumarioVentas>(SumarioVentass, totalRegistros, query.Limit);
        }

        #endregion

        #region Métodos de operaciones de la clase

        private int GrabarSumarioVentas(GrabarSumarioVentasRequest request)
        {
            SqlServer.AddParameter("@iduser", SqlDbType.Int, 1);
            var dataSetP = SqlServer.ExecuteProcedure("sp_eliminartabla");


            foreach (SumarioVentas s in request.sumario)
            {
                // Se establecen los parámetros del procedimiento a ejecutar
                SqlServer.AddParameter("@i_accion", SqlDbType.Char, s.IdSumarioVentas.Equals(0) ? "I" : "M");
                SqlServer.AddParameter("@i_id_sumario_venta", SqlDbType.Int, s.IdSumarioVentas);
                SqlServer.AddParameter("@i_cantidad_factura", SqlDbType.Float, s.CantidadFactura);
                SqlServer.AddParameter("@i_total_facturas", SqlDbType.Int, s.TotalFacturas);
                SqlServer.AddParameter("@i_clienteId", SqlDbType.Int, s.ClienteId);

                // Se realiza la consulta a la base de datos
                var dataSet = SqlServer.ExecuteProcedure("pr_sumarioVentas");
            }




            return 1;

            
        }

        #endregion
    }
}