using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.Model
{
    public abstract class BaseData
    {
        public DataRow Row {get; set;}

        public T GetValue<T>(string name)
        {
            try
            {
                return Row[name] != DBNull.Value ? (T)Row[name] : default(T);
            }
            catch (Exception){
                return default(T);
            }
            
        }

        public DateTime? GetDate(string name) {
            try
            {

                if (Row[name] != DBNull.Value)
                {
                    var dateString = Row[name].ToString();
                    return Tools.ToDisplayTime(dateString);
                } else throw new Exception("Fecha nula");
            }
            catch (Exception) {
                return null;
            }
            
        }
    }
}
