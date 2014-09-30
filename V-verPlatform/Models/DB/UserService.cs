using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V_verPlatform.Models.DB
{
    /// <summary>
    /// 用户服务类
    /// </summary>
    public class UserService
    {

        userDBEntities bs = new userDBEntities();
        public int AddUser(userInfo user)
        {
            bs.userInfo.Add(user);
            return bs.SaveChanges();
        }
    }
}