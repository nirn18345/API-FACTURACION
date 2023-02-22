namespace APIPrueba.Utils
{
    internal class StringHandler
    {
        internal const string Environment = "ASPNETCORE_ENVIRONMENT";

      //  internal const string NuevoController = "Facturacion";
        // Nombres de módulo y proyecto
        internal const string ModuleName = "Modulo";
        internal const string ProjectName = "Proyecto";

        // Nombres de procedimientos
        internal const string Database = "DATABASE";
        internal const string ProcedureExample = "pr_ejemplo";
        internal const string ProcedureFactura = "pr_factura";
        internal const string ProcedureDetalleF = "pr_det_factura";

        public static string OK;

        // Códigos de error
        internal const string CODE_ERROR_VAL_01 = "VAL-01";

        // Mensajes de error
        internal const string ERROR_VAL_01 = "No existe un registro";

    }
}