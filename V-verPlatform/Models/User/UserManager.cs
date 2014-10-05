using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using V_verPlatform.Models.DB;
namespace V_verPlatform.Models
{
    public class UserManager:IRequiresSessionState
    {
       // http://blog.csdn.net/byondocean/article/details/7164117
        UserService us=new UserService();
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
            try
            {
                if (usin == null)
                {
                    return 0;
                }
                else
                {
                    return usin.power;
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 添加账户
        /// </summary>
        /// <param name="usin"></param>
        /// <returns></returns>
        public int register(userInfo usin)
        {
            if (us.AddUser(usin))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

    }
}