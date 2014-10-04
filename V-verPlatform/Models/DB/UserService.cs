using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace V_verPlatform.Models.DB
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService
    {

        //说好的EF+sdf不见了
        static public String conStr = ConfigurationManager.ConnectionStrings["vverDB"].ConnectionString;
        userDBEntities bs = new userDBEntities();
        public int AddUser(userInfo user)
        {
            bs.userInfo.Add(user);
            return bs.SaveChanges();
        }
        public List<Models.DB.userInfo> goList()
        { 
            return (from d in bs.userInfo where true select d).ToList<Models.DB.userInfo>();
        }
        public userInfo goUserinfo(int ID)
        {
            return (from d in bs.userInfo where d.ID == ID select d).ToList<userInfo>()[0];
        }
    }
}