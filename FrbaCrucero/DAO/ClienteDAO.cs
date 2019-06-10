using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FrbaCrucero.Model;
using FrbaCrucero.Exceptions;

namespace FrbaCrucero.DAO
{
    public class ClienteDAO : BaseDAO<Cliente>
    {
        public ClienteDAO(DBConnection con) : base(con) { }

        public int CreateOrUpdate(Cliente cliente, bool esInsert)
        {
            if (esInsert)
            {
                if (!ExisteCliente(cliente.NumeroDocumento))
                    return GuardarCliente(cliente);
                else
                {
                    throw new ClienteException("Existe un cliente registrado con el DNI ingresado.");
                }
            }
            else
                return GuardarCliente(cliente);
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

        public List<Cliente> GetClientes(decimal numeroDocumento, string nombre, string apellido, string inconsistente)
        {
            var list = new List<Cliente>();

            var query = ArmarSentenciaSP("P_Obtener_Clientes", new[] {
                GetParam(numeroDocumento),
                GetParam(nombre),
                GetParam(apellido),
                GetParamVigencia(inconsistente) });
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
