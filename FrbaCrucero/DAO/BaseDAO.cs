using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAO
{
    public abstract class BaseDAO<T>
    {
        protected DBConnection Connection;

        protected BaseDAO(DBConnection connection){
            Connection = connection;
        }
        
        public virtual void Delete(Object obj) { }

        //public virtual T FindById(int id) { }

        /// <summary>
        /// Esta función se utiliza para incluir una sentencia dentro del esquema de una transacción.
        /// </summary>
        /// <param name="sentencia">String - Sentencia SQL para incluir en una transaccón. Se necesita realizar el COMMIT TRAN dentro de la sentencia enviada y los parametro</param>
        /// <returns>Una nueva sentencia construida a partir de la sentencia original</returns>
        public string IncluirEnTransaccion(String sentencia)
        {
            var transaccion = "";
            transaccion += "BEGIN TRY\n";
            transaccion += "BEGIN TRANSACTION\n";
            transaccion += sentencia;
            transaccion += "COMMIT TRANSACTION;\n";
            transaccion += "END TRY\n";
            transaccion += "BEGIN CATCH\n";
            transaccion += "DECLARE @ErrorMessage NVARCHAR(4000); DECLARE @ErrorSeverity INT; DECLARE @ErrorState INT;  SELECT @ErrorMessage = ERROR_MESSAGE(), @ErrorSeverity = ERROR_SEVERITY(), @ErrorState = ERROR_STATE();  RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState );\n";
            transaccion += "ROLLBACK TRANSACTION;\n";
            transaccion += "END CATCH;";
            return transaccion;
        }

        /// <summary>
        /// Esta función se utiliza para armar la sentencia que invoca a un Store Procedure
        /// </summary>
        /// <param name="nombreSp">Nombre del Store Procedure que se va invocar</param>
        /// <param name="parametros">Lista de parámetros que tiene el Store Procedure a invocar</param>
        /// <returns></returns>
        public string ArmarSentenciaSP(string nombreSp, string[] parametros)
        {
            var sqlStatement = "EXEC DSW." + nombreSp + " ";
            if (parametros == null || !parametros.Any())
            { // Agregado para llamar a SPs sin parametros de entrada
                return sqlStatement + ";";
            }

            sqlStatement += string.Join(", ", parametros);
            return sqlStatement + ";";
        }
        public string GetParam(bool param)
        {
            return param ? "1" : "0";
        }
        public string GetParam(string param) {
            return !string.IsNullOrEmpty(param) ? "'" + param + "'" : "null";
        }
        public string GetParam(DateTime? param) {
            return param != null ? "'" + Tools.ToDataBaseTime(param.Value) + "'" : "null";
        }
        public string GetParam(int param) {
            return param.ToString();
        }
        public string GetParam(decimal param)
        {
            return param.ToString("0.00", CultureInfo.InvariantCulture);
        }
        public string GetParamVigencia(string param) {
            return param == "Todos" ? "null" : param == "No" ? "1" : "0";
        }
        //public string GetParam(Usuario param)
        //{
        //    return param != null && param.Id > 0 ? param.Id.ToString() : "null"; ;
        //}
        //public string GetParam(Cliente param)
        //{
        //    return param != null && param.Id > 0 ? param.Id.ToString() : "null"; ;
        //}
    }
}
