using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace DataAccessLayer
{
    public class Mapper
    {
        //signature method
        public void Assert(bool condition, string message)
        {
            if (!condition)
            {
                throw new Exception(message);
            }
        }
        public string GetstringOrDefault(SqlDataReader reader,int ordinal, string defaultvalue = "")
        {
            if (reader.IsDBNull(ordinal))
            {
                return defaultvalue;
            }
            else
            {
                return reader.GetString(ordinal);
            }
        }
        public int 
            Getint32OrDefault(SqlDataReader reader,int ordinal,int defaultValue = 0)
        {
            if (reader.IsDBNull(ordinal))
            {
                return defaultValue;
            }
            else
            {
                return reader.GetInt32(ordinal);
            }
        }
        public DateTime
            GetDateTimeOrDefault(SqlDataReader reader,int ordinal,DateTime Defaultvalue)
        {
            if (reader.IsDBNull(ordinal))
            {
                return Defaultvalue;
            }
            else
            {
                return reader.GetDateTime(ordinal);
                    
                
            }
        }
    }
}
