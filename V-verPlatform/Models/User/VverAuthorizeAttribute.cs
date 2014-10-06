using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using V_verPlatform.Controllers;
using V_verPlatform.Models.DB;

namespace V_verPlatform.Models
{
    /// <summary>
    /// 奇葩验证机制
    /// 是这么回事，本登陆系统使用Cookie+session双重认证模式，主要是在危险不高的情况下用cookie可以很轻松地登陆，如果在一些其他的环节就需要验证密码，大概就是这个样子
    /// Role 主要结合cookie
    /// User 结合session
    /// </summary>
    public class VverAuthorizeAttribute:AuthorizeAttribute
    {
        
//   代码顺序为：OnAuthorization-->AuthorizeCore-->HandleUnauthorizedRequest
//如果AuthorizeCore返回false时，才会走HandleUnauthorizedRequest 方法，并且Request.StausCode会返回401，401错误又对应了Web.config中
//的
//<authentication mode="Forms">
//      <forms loginUrl="~/" timeout="2880" />
//    </authentication>
//所有，AuthorizeCore==false 时，会跳转到 web.config 中定义的  loginUrl="~/"
        static public int Power;
        static public int ID;
        static public String Name;
        static public String users;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null || authCookie.Value == "")
            {
                return false;
            }
            FormsAuthenticationTicket authTicket;
            try
            {
                //对当前的cookie进行解密   
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch
            {
                return false;
            }
            try
            {
                if (authTicket != null)
                {
                    //和存入时的分隔符有关系，此处存入时的分隔符为逗号   
                    List<String> userDate = authTicket.UserData.Split(new[] { ',' }).ToList();
                    ID = Convert.ToInt32(userDate[0]);
                    Power = Convert.ToInt32(userDate[1]);
                    users = UserManager.Classification(Power);
                    Name = authTicket.Name;
                    List<String> roles = Roles.Split(new[] { ',' }).ToList();
                    List<String> okusers = Users.Split(new[] { ',' }).ToList();
                    if (Users == "")
                    {
                        return roles.Contains(users);
                    }
                    else
                    {
                        if (!(UserController.userManger.usinfo == null))
                        {
                            return roles.Contains(users);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    
                }
            }
            catch
            {
                return false;
            }
            return false;
        }
        
    }
}