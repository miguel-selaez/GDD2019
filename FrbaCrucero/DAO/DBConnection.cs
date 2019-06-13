using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;
using FrbaCrucero.Exceptions;

namespace FrbaCrucero.DAO
{
    /// <summary>
    /// Clase de _connection a una base de datos generica
    /// </summary>
    public class DBConnection
    {
        private string _stringConnection;
        private OleDbConnection _connection;
        private OleDbCommand _command;
        private int _timeOut;

        protected int TimeOut
        {
            get
            {
                _timeOut = ConfigurationManager.AppSettings["TimeOut"] != null ? Convert.ToInt32(ConfigurationManager.AppSettings["TimeOut"]) : 30;
                return _timeOut;
            }
        }

        /// <summary>
        /// Utiliza el string de _connection creado en el archivo de configuracion app.config
        /// </summary>
        /// <param name="connectionName">Nombre de la _connection</param>
        public DBConnection(String connectionName) {
            _stringConnection = ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        /// <summary>
        /// Esta función se encarga de ejecutar una sentencia sql que no retorna valores
        /// </summary>
        /// <param name="query">Sentencia a ejecutar</param>
        public void ExecuteNoQuery(String query)
        {
            try
            {
                using (_connection = new OleDbConnection(_stringConnection))
                {
                    _connection.Open();

                    _command = new OleDbCommand(query, _connection);

                    _command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new DBConnectionException(ex.Message);
            }
            finally
            {
                if(_command != null)
                    _command.Dispose();
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
        }

        /// <summary>
        /// Esta función se encarga de ejecutar una sentencia sql que realiza consultas con la devolucion de un valor
        /// </summary>
        /// <param name="query">Sentencia a ejecutar</param>
        public string ExecuteSingleResult(string query)
        {
            try
            {
                using (_connection = new OleDbConnection(_stringConnection))
                {
                    _connection.Open();

                    _command = new OleDbCommand(query, _connection) { CommandTimeout = TimeOut };

                    var id = _command.ExecuteScalar().ToString();
                    return id;
                }
            }
            catch (Exception ex)
            {
                throw new DBConnectionException(ex.Message);
            }
            finally
            {
                if (_command != null)
                    _command.Dispose();
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
        }

        /// <summary>
        /// Ejecuta una sentencia sql y retorna un dataTable con sus datos
        /// </summary>
        /// <param name="sentencia">sentencia a ejecutar - String</param>
        /// <returns>resultado de la consulta - dataTable</returns>
        public DataTable ExecuteQuery(String query)
        {

            DataTable data = new DataTable();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            try
            {
                using (_connection = new OleDbConnection(_stringConnection))
                {
                    _connection.Open();

                    _command = new OleDbCommand(query, _connection) { CommandTimeout = TimeOut };

                    adapter.SelectCommand = _command;

                    adapter.Fill(data);

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new DBConnectionException(ex.Message);
            }
            finally
            {
                if (_command != null)
                    _command.Dispose();
                if (adapter != null)
                    adapter.Dispose();
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
        }

        /// <summary>
        /// Ejecuta una sentencia sql y retorna un DataSet con los multiples resultados
        /// </summary>
        /// <param name="sentencia"></param>
        /// <returns>resultado de la consulta - dataSet</returns>
        public DataSet ExecuteMultipleResult(String sentencia)
        {

            DataSet data = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            try
            {
                using (_connection = new OleDbConnection(_stringConnection))
                {
                    _connection.Open();

                    _command = new OleDbCommand(sentencia, _connection) { CommandTimeout = TimeOut };

                    adapter.SelectCommand = _command;

                    adapter.Fill(data);

                    return data;
                }
            }
            catch (Exception ex)
            {
                throw new DBConnectionException(ex.Message);
            }
            finally
            {
                if (_command != null)
                    _command.Dispose();
                if (adapter != null)
                    adapter.Dispose();
                if (_connection != null)
                {
                    _connection.Close();
                    _connection.Dispose();
                }
            }
        }
    }
}
