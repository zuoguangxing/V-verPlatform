using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Text;

namespace V_verPlatform.Models.DB
{
    public class ZGXSQLHelper
    {
        static List<String> TypeOneList = new List<String>() { "System.DateTime", "System.String" };

        static public String SqlInsertDataToSqlStr<T>(String TableName, T t,List<String> ignore)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            sb.Append("INSERT INTO " + TableName + " (");
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                if(!ignore.Contains(info.Name))
                {
                try
                { 
                    sb.Append(" " + info.Name +",");
                     Object ob = new Object();
                    if(info.GetValue(t, null)!=null)
                    {
                    if (TypeOneList.Contains(info.PropertyType.FullName))
                    {
                        sb2.Append(" '" + info.GetValue(t, null) + "',");
                    }
                    else
                    {
                        if (info.PropertyType.IsEnum)
                        {
                            sb2.Append(" " + (Int32)info.GetValue(t, null) + ",");
                        }
                        else
                        {
                            sb2.Append(" " + info.GetValue(t, null).ToString() + ",");
                        }
                    }
                    }
                }
                catch (Exception e)
                {

                }
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES(");
            sb2.Remove(sb2.Length - 1, 1);
            sb.Append(sb2.ToString());
            sb.Append(")");
            return sb.ToString();
        }
        static public String SqlInsertDataToSqlStr<T>(String TableName,T t)
        {
            StringBuilder sb = new StringBuilder();
            StringBuilder sb2 = new StringBuilder();
            sb.Append("INSERT INTO " + TableName + " (");
            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                try
                { 
                    sb.Append(" " + info.Name +",");
                     Object ob = new Object();
                    if(info.GetValue(t, null)!=null)
                    {
                    if (TypeOneList.Contains(info.PropertyType.FullName))
                    {
                        sb2.Append(" '" + info.GetValue(t, null) + "',");
                    }
                    else
                    {
                        if (info.PropertyType.IsEnum)
                        {
                            sb2.Append(" " + (Int32)info.GetValue(t, null) + ",");
                        }
                        else
                        {
                            sb2.Append(" " + info.GetValue(t, null).ToString() + ",");
                        }
                    }
                    }
                }
                catch (Exception e)
                {

                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append(") VALUES(");
            sb2.Remove(sb2.Length - 1, 1);
            sb.Append(sb2.ToString());
            sb.Append(")");
            return sb.ToString();
        }
        static public Boolean SqlInsertData<T>(String conStr,String TableName, T t)
        {
            String sql = SqlInsertDataToSqlStr(TableName,t);
            SqlHelper.ExecuteNonQuery(conStr, System.Data.CommandType.Text, sql);
            return true;
        }
        static public Boolean SqlInsertData<T>(String conStr, String TableName, T t, List<String> ignore)
        {
            String sql = SqlInsertDataToSqlStr(TableName, t, ignore);
            SqlHelper.ExecuteNonQuery(conStr, System.Data.CommandType.Text, sql);
            return true;
        }
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
        static public String SQLFileIntoString(string path)
        {
            StreamReader sr = new StreamReader(path, Encoding.Default);
            String str = sr.ReadToEnd();
            str = str.Replace("\r", " ");
            str = str.Replace("\n", " ");
            str = str.Replace("\t", " ");
            str = str.Replace("GO", " ");
            sr.Close();
            return str;
        }
    }
}