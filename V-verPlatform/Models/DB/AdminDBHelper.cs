using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace V_verPlatform.Models.DB
{
    public class AdminDBHelper
    {
        public static Boolean InitializeDatabase()
        {
            if (DeleteAllTable())
            {
                if (CreateAllTable())
                {
                    return true;
                }
            }
            return false;
        }
        public static Boolean CreateAllTable()
        {
            String[] files = Directory.GetFiles(System.Web.HttpContext.Current.Server.MapPath("~/somefile/sqlfile/SqlTableCreateFile"), "*.sql", SearchOption.AllDirectories);
            foreach (String file in files)
            {
                String str = ZGXSQLHelper.SQLFileIntoString(file);
                SqlHelper.ExecuteNonQuery(SqlHelper.conStr, System.Data.CommandType.Text, str);
            }
            return true;
        }
        public static Boolean DeleteAllTable()
        {
            String strfile = System.Web.HttpContext.Current.Server.MapPath("~/somefile/sqlfile/deletealltable.sql");
            String str = ZGXSQLHelper.SQLFileIntoString(strfile);
            SqlHelper.ExecuteNonQuery(SqlHelper.conStr, System.Data.CommandType.Text, str);
            return true;
        }
    }
}