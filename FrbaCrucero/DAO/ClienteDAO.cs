using FrbaCrucero.Exceptions;
using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class ClienteDAO : BaseDAO<Cliente>
    {
        public ClienteDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Cliente cliente, bool esInsert)
        {
                if (!ExisteCliente(cliente.NumeroDocumento))
                    return GuardarCliente(cliente);
                else
                {
                    throw new ClienteException("Existe un cliente registrado con el DNI ingresado.");
                }
        }

        private int GuardarCliente(Cliente cliente)
        {           
            var query = "" ;
            query += "DECLARE @v_c_id INT;";
            query += "SET @v_c_id = " + cliente.Id + ";";
            query += ArmarSentenciaSP("P_Guardar_Cliente", new[] {
                        "@v_c_id out",
                        GetParam(cliente.Nombre),
                        GetParam(cliente.Apellido),
                        GetParam(cliente.NumeroDocumento),
                        GetParam(cliente.Direccion),
                        GetParam(cliente.Telefono),
                        GetParam(cliente.Mail),
                        GetParam(cliente.FechaNacimiento)                        
                    });
            query += "SELECT @v_c_id;";
            query = IncluirEnTransaccion(query);
            return Int32.Parse(Connection.ExecuteSingleResult(query));
        }

        public bool ExisteCliente(decimal Dni)
        {
            var query = "DECLARE @v_flag bit;";
            query += ArmarSentenciaSP("P_Validar_Dni_CLiente", new[] { GetParam(Dni), "@v_flag output" });
            query += "SELECT @v_flag;";

            var result = Connection.ExecuteSingleResult(query);
            if (result.Equals("False"))
                return false;
            else
                return true;
        }

        public Cliente GetCliente(int id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Cliente", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new Cliente(result.Rows[0]);
        }

        public List<Cliente> GetClientes(decimal numeroDocumento, string nombre, string apellido, string inconsistente, int page, int offset)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Clientes", new[] {
                GetParam(numeroDocumento),
                GetParam(nombre),
                GetParam(apellido),
                GetParamInconsistente(inconsistente),
                GetParam(page),
                GetParam(offset)
            });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Cliente(row));
                }
            }
            return list;
        }

        public int GetClientesCount(decimal numeroDocumento, string nombre, string apellido, string inconsistente)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Cantidad_Clientes", new[] {
                GetParam(numeroDocumento),
                GetParam(nombre),
                GetParam(apellido),
                GetParamInconsistente(inconsistente)
            });
            var result = Connection.ExecuteQuery(query);
            return result.Rows[0].GetValue<int>("count");
        }

        public List<Cliente> GetClientesxEstadia(int estadiaId)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Huespedes_x_Estadia", new[] { GetParam(estadiaId) });
            var result = Connection.ExecuteQuery(query);

            if (result.Rows.Count > 0)
            {
                foreach (DataRow row in result.Rows)
                {
                    list.Add(new Cliente(row));
                }
            }
            return list;
        }
    }
}
