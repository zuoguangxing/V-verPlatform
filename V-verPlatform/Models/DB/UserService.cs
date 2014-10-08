using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace V_verPlatform.Models.DB
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService
    {

        //说好的EF+sdf不见了
        static public String conStr = ConfigurationManager.ConnectionStrings["vverDB"].ConnectionString;
        public List<Models.DB.userInfo> goList()
        {
            List<Models.DB.userInfo> list = new List<userInfo>();
            DataSet wangji = SqlHelper.ExecuteDataset(UserService.conStr, CommandType.Text, "SELECT * FROM UserNP");
            DataTable table = wangji.Tables[0];
            DataRowCollection rows = table.Rows;
            foreach (DataRow row in rows)
            {
                list.Add(new userInfo()
                {
                    ID=(int)row["ID"],
                    Name=(string)row["Name"],
                    pw=(string)row["Password"],
                    power=(byte)row["power"]
                }
                    );
            }
            //DataRow row = rows[0];
            //return (String)row["Name"];
            return list;
        }
        #region 返回单一账号信息
        /// <summary>
        /// 返回一个人的账号信息通过ID，如果没有这个人则返回NULL
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public userInfo goUserinfo(int ID)
        {
            SqlDataReader sqdr = SqlHelper.ExecuteReader(UserService.conStr, CommandType.Text, "SELECT * FROM UserNP WHERE ID="+ID.ToString());
            if (sqdr.Read())
            {
                userInfo us = new userInfo()
                {
                    ID = (int)sqdr["ID"],
                    Name = (string)sqdr["Name"],
                    pw = (string)sqdr["Password"],
                    power = (byte)sqdr["power"]
                };
                sqdr.Close();
                return us;
            }
            else {
                sqdr.Close(); return null;
            }
        }
        /// <summary>
        /// 返回一个人的账号信息通过NAME和密码，如果没有这个人则返回NULL
        /// </summary>
        /// <param name="name"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public userInfo goUserinfo(String name, String Password)
        {
            SqlDataReader sqdr = SqlHelper.ExecuteReader(UserService.conStr, CommandType.Text, "SELECT * FROM UserNP WHERE Name='" + name+"' and Password='"+Password+"'");
            if (sqdr.Read())
            {
                userInfo us = new userInfo()
                {
                    ID = (int)sqdr["ID"],
                    Name = (string)sqdr["Name"],
                    pw = (string)sqdr["Password"],
                    power = (byte)sqdr["power"]
                };
                sqdr.Close();
                return us;
            }
            else
            {
                sqdr.Close(); return null;
            }
        }
        #endregion
        #region 写入注册相关
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(userInfo user)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(conStr, CommandType.Text, "INSERT INTO UserNP (Name,Password,power,email) VALUES('" + user.Name + "','" + user.pw + "'," + 1 +",'"+user.email+"')");
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}