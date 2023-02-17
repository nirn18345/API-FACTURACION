using APIPrueba.Entidades.Consultas;
using APIPrueba.Entidades.Operaciones;
using APIPrueba.Utils;
using GDifare.Utilitario.BaseDatos;
using GDifare.Utilitario.Comun;
using MicroserviciosGD1.Entidades.Consultas;
using System;
using System.Data;

namespace APIPrueba.Datos
{
    public interface IMapeoDatosCliente
    {
        Cliente Obtener(int idCliente);
        PagedCollection<Cliente> ObtenerListado(ListarClienteQuery query);
        GrabarClienteResponse Grabar(GrabarClienteRequest request);
    }

    public class MapeoDatosCliente : MapeoDatosBase, IMapeoDatosCliente
    {
        #region Constructores de la clase

        public MapeoDatosCliente(ISqlServer _sqlServer)
            : base(_sqlServer) { }

        #endregion

        #region Implementación de la interface

        GrabarClienteResponse IMapeoDatosCliente.Grabar(GrabarClienteRequest request)
        {
            // Cliente: Se valida si existe el registro
            if (request.IdCliente > 0)
            {
                var Cliente = ObtenerCliente(request.IdCliente);

                // Si no existe se genera una respuesta de operación no exitosa.
                if (Cliente == null)
                {
                    return new GrabarClienteResponse(
                        MensajesCliente.CODE_ERROR_VAL_01,
                        MensajesCliente.ERROR_VAL_01);
                }
            }

            // Se graba el registro
            var idCliente = GrabarCliente(request);

            return new GrabarClienteResponse()
            {
                IdCliente = idCliente
            };
        }

        Cliente IMapeoDatosCliente.Obtener(int idCliente)
        {
            return ObtenerCliente(idCliente);
        }

        PagedCollection<Cliente> IMapeoDatosCliente.ObtenerListado(ListarClienteQuery query)
        {
            return ObtenerListadoClientes(query);
        }

        #endregion

        #region Métodos de consulta de la clase

        private Cliente ObtenerCliente(int idCliente)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "C");
            SqlServer.AddParameter("@i_id_cliente", SqlDbType.Int, idCliente);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure("pr_cliente");

            if (dataSet.Tables.Count == 0) return null;
            if (dataSet.Tables[0].Rows.Count == 0) return null;

            var Cliente = ConvertTo<Cliente>(dataSet.Tables[0]);

            // Se devuelve el objeto
            return Cliente;
        }

        private PagedCollection<Cliente> ObtenerListadoClientes(ListarClienteQuery query)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, "G");
            SqlServer.AddParameter("@i_offset", SqlDbType.Int, query.Offset);
            SqlServer.AddParameter("@i_limit", SqlDbType.Int, query.Limit);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure("pr_cliente");

            // Se genera la consulta paginada
            var totalRegistros = Convert.ToInt32(dataSet.Tables[0].Rows[0]["total_registros"]);
            var Clientes = ConvertToList<Cliente>(dataSet.Tables[1]);

            // Se devuelve el objeto
            return new PagedCollection<Cliente>(Clientes, totalRegistros, query.Limit);
        }

        #endregion

        #region Métodos de operaciones de la clase

        private int GrabarCliente(GrabarClienteRequest request)
        {
            // Se establecen los parámetros del procedimiento a ejecutar
            SqlServer.AddParameter("@i_accion", SqlDbType.Char, request.IdCliente.Equals(0) ? "I" : "M");
            SqlServer.AddParameter("@i_id_cliente", SqlDbType.Int, request.IdCliente);
            SqlServer.AddParameter("@i_nombre", SqlDbType.VarChar, request.Nombre);
            SqlServer.AddParameter("@i_apellido", SqlDbType.VarChar, request.Apellido);
            SqlServer.AddParameter("@i_cedula", SqlDbType.VarChar, request.Cedula);
            SqlServer.AddParameter("@i_correo", SqlDbType.VarChar, request.Correo);
            SqlServer.AddParameter("@i_telefono", SqlDbType.VarChar, request.Telefono);
            SqlServer.AddParameter("@i_direccion", SqlDbType.VarChar, request.Direccion);
            SqlServer.AddParameter("@i_estado", SqlDbType.Char, request.Estado);

            // Se realiza la consulta a la base de datos
            var dataSet = SqlServer.ExecuteProcedure("pr_cliente");

            

            return int.Parse(dataSet.Tables[0].Rows[0]["idCliente"].ToString());

            
        }

        #endregion
    }
}