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

        //public void CreateOrUpdate(Cliente cliente, bool esInsert)
        //{
        //    if (esInsert)
        //    {
        //        if (!ExisteCliente(cliente.Persona.Mail))
        //            GuardarCliente(cliente);
        //        else
        //        {
        //            throw new ClienteException("Existe un cliente registrado con el mail ingresado.");
        //        }
        //    }
        //    else
        //        GuardarCliente(cliente);
        //}

        //private void GuardarCliente(Cliente cliente)
        //{
        //    var personaQuery = DAOFactory.PersonaDAO.CreateOrUpdateScript(cliente.Persona);

        //    var query = personaQuery;
        //    query += "DECLARE @id_cliente int;";
        //    query += ArmarSentenciaSP("P_Guardar_Cliente", new[] {
        //                GetParam(cliente.Id),
        //                "@id_persona",
        //                GetParam(cliente.Baja),
        //                "@id_cliente output"
        //            });

        //    query = IncluirEnTransaccion(query);

        //    Connection.ExecuteQuery(query);
        //}

        //public bool ExisteCliente(string mail)
        //{
        //    var query = "DECLARE @v_flag bit;";
        //    query += ArmarSentenciaSP("P_Validar_Mail_CLiente", new[] { GetParam(mail), "@v_flag output" });
        //    query += "SELECT @v_flag;";

        //    var result = Connection.ExecuteSingleResult(query);
        //    if (result.Equals("False"))
        //        return false;
        //    else
        //        return true;
        //}

        //public List<Cliente> GetClientes(string tipoDocumento, decimal numeroDocumento, string mail, string vigencia)
        //{
        //    var list = new List<Cliente>();

        //    var query = ArmarSentenciaSP("P_Obtener_Clientes", new[] { GetParam(tipoDocumento), GetParam(numeroDocumento), GetParam(mail), GetParamVigencia(vigencia) });
        //    var result = Connection.ExecuteQuery(query);

        //    if (result.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in result.Rows)
        //        {
        //            list.Add(new Cliente(row));
        //        }
        //    }
        //    return list;
        //}

        //public List<Cliente> GetClientesxEstadia(int estadiaId)
        //{
        //    var list = new List<Cliente>();

        //    var query = ArmarSentenciaSP("P_Obtener_Huespedes_x_Estadia", new[] { GetParam(estadiaId) });
        //    var result = Connection.ExecuteQuery(query);

        //    if (result.Rows.Count > 0)
        //    {
        //        foreach (DataRow row in result.Rows)
        //        {
        //            list.Add(new Cliente(row));
        //        }
        //    }
        //    return list;
        //}
    }
}
