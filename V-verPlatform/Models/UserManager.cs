using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V_verPlatform.Models.DB;
namespace V_verPlatform.Models
{
    public class UserManager
    {
        UserService us=new UserService();
        public int AddUser(userInfo user)
        {
            return us.AddUser(user);
        }
        public List<Models.DB.userInfo> goList()
        {
            return us.goList();
        }
        /// <summary>
        /// 这个东西是用来做验证的，返回0就说明没有登录成功
        /// </summary>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int verification(String name, String password)
        {
            userInfo usin = us.goUserinfo(name, password);
            if (usin == null)
            {
                return 0;
            }
            else {
                return usin.power;
            }
        }
    }
}