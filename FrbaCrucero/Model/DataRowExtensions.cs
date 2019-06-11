using System;
using System.Data;

namespace FrbaCrucero.Model
{
    public static class DataRowExtensions
    {
        public static T GetValue<T>(this DataRow row, string name){
            try
            {
                return row[name] != DBNull.Value ? (T)row[name] : default(T);
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static DateTime? GetDate(this DataRow row, string name)
        {
            try
            {

                if (row[name] != DBNull.Value)
                {
                    var dateString = row[name].ToString();
                    return Tools.ToDisplayTime(dateString);
                }
                else throw new Exception("Fecha nula");
            }
            catch (Exception)
            {
                return null;
            }

        }
    }
}
