using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;

namespace V_verPlatform.Models.DB
{
    public class ZGXSQLHelper
    {
        static public T SqlDataReaderToSolidmodel<T>(SqlDataReader reader) where T:new()
        {
            T t = new T();
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                try
                {
                    info.SetValue(t, reader[info.Name], null);
                }
                catch (Exception e)
                {

                }
            }
            return t;
        }
        static public List<T> SqlDataReaderToSolidmodelList<T>(SqlDataReader reader) where T : new()
        {
            List<T> list = new List<T>();
            if(reader.HasRows)
            {
                do
                {
                    list .Add( SqlDataReaderToSolidmodel<T>(reader));
                }
                while (reader.Read());
            }
            return list;
        }
    }
}