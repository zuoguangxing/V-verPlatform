using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.SessionState;
using V_verPlatform.Models.DB;
namespace V_verPlatform.Models
{
    public class UserManager:IRequiresSessionState
    {
       // http://blog.csdn.net/byondocean/article/details/7164117
        /// <summary>
        /// 根据power分级权限
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        static public String Classification ( int power)
        {
            if(power<3)
            {
                return "Guest";
            }
            else if(power <=6)
            {
                return "User";
            }
            else if(power <=9)
            {
                return "PowerManager";
            }
            else if(power==10)
            {
                return "Admin";
            }
            else
            {
                return "Guest";
            }
        }
        UserService us=new UserService();
        public userInfo usinfo;
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
            usinfo = us.goUserinfo(name, password);
            try
            {
                if (usinfo == null)
                {
                    return 0;
                }
                else
                {
                    FormsAuthenticationTicket Ticket = new FormsAuthenticationTicket(2,usinfo.Name, DateTime.Now, DateTime.Now.AddMinutes(60), false, usinfo.ID+","+ usinfo.power.ToString(), "vver/");
                    string HashTicket = FormsAuthentication.Encrypt(Ticket);
                    HttpCookie UserCookie = new HttpCookie(FormsAuthentication.FormsCookieName, HashTicket);
                    HttpContext.Current.Response.Cookies.Add(UserCookie);
                    return usinfo.power;
                }
            }
            catch
            {
                return -1;
            }
        }
        /// <summary>
        /// 添加账户返回1为成功
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