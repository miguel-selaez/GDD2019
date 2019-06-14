using FrbaCrucero.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FrbaCrucero.DAO
{
    public class PagoDAO : BaseDAO<Pago>
    {
        public PagoDAO(DBConnection con) : base(con) { }

        public decimal CreateOrUpdate(Pago pago)
        {
            var query = ArmarSentenciaSP("P_Guardar_Pago", new[] { GetParam(pago.Id), GetParam(pago.CantidadCuotas), GetParam(pago.FechaCompra), GetParam(pago.Total), GetParam(pago.Cliente.Id), GetParam(pago.MedioPago.Id) });
            pago.Id = Int32.Parse(Connection.ExecuteSingleResult(query));

            foreach (Model.Pasaje pasaje in pago.Pasajes)
            {
                pasaje.Pago = pago;
                pasaje.Cliente = pago.Cliente;
                DAO.DAOFactory.PasajeDAO.CreateOrUpdate(pasaje);
            }
            return pago.Id;
        }

        public Pago GetPago(decimal id)
        {
            var query = ArmarSentenciaSP("P_Obtener_Pago", new[] { GetParam(id) });
            var result = Connection.ExecuteQuery(query);
            return new Pago(result.Rows[0]);
        }

        public DataRow GetDatosViaje(decimal id_reserva)
        {
            var query = ArmarSentenciaSP("P_Obtener_datos_viaje", new[] { GetParam(id_reserva) });
            var result = Connection.ExecuteMultipleResult(query);
            return result.Tables[0].Rows[0];
        }          

        public DataTable GetPasajes(decimal id_reserva)
        {
            var query = ArmarSentenciaSP("P_Obtener_pasajes_reserva", new[] { GetParam(id_reserva) });
            return Connection.ExecuteQuery(query);
        }
        
        public decimal GetPrecioTotalPasajes(decimal id_reserva)
        {
            var query = ArmarSentenciaSP("P_Obtener_precio_total_pasajes", new[] { GetParam(id_reserva) });
            return decimal.Parse(Connection.ExecuteSingleResult(query));
        }

        public int SetPagoAPasaje(decimal id_reserva, int medio_pago, int cant_cuotas, decimal total)
        {
            var query = ArmarSentenciaSP(
                            "P_Guardar_pago_a_pasaje", 
                            new[] {
                                    GetParam(id_reserva),
                                    GetParam(medio_pago),
                                    GetParam(cant_cuotas),
                                    GetParam(total),
                                    GetParam(Tools.GetDate())
                            });
            return Int32.Parse(Connection.ExecuteSingleResult(query));    
        }

        public int GuardarPasajes(List<Pasaje> pasajes, Pago pago)
        {
            var query = "DECLARE @id_pago int;";

            query += ArmarSentenciaSP("P_Guardar_pago", new[] {"@id_pago OUT, ", GetParam(pago.Total), GetParam(pago.FechaCompra), GetParam(pago.CantidadCuotas), GetParam(pago.Cliente.Id), GetParam(pago.MedioPago.Id)});


            foreach (Pasaje p in pasajes)
            {
                query += ArmarSentenciaSP("P_Guardar_pasaje", new[]{GetParam(p.Precio),GetParam(p.Viaje.Id),GetParam(p.Cabina.Id),"null",GetParam(p.Cliente.Id),"@id_pago"});
            }

            query += "SELECT @id_pago;";

            return Int32.Parse(Connection.ExecuteSingleResult(query));
        }
    }
}
