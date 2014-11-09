using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models;
using V_verPlatform.Models.DB;

namespace V_verPlatform.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        public static UserManager userManger = new UserManager();
        /// <summary>
        /// 用来判断返回登陆消息值 一般为0,1的时候提示注册成功
        /// </summary>
        public static int loginInformationSigns = 0;
        [VverAuthorize(Roles = "Admin,PowerManager,Guest,User")]
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Login的重用，如果登陆失败会回到这个里面来，这个什么都没有的是默认的
        /// </summary>
        /// <returns></returns>
        public ActionResult Login(String ReturnUrl=null)
        {
            if (loginInformationSigns == 1)
            {
                ViewBag.Message = "Registration is successful, you can log in now!";
                loginInformationSigns = 0;
                return View();
            }
            Session["ReturnUrl"] = ReturnUrl;
            return View();
        }
        /// <summary>
        /// 这个是一次验证Login 如果成功 那么干了2个事情，一个是发cookie 另一个是写session[ui]
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pw"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(String act,String pvd)
        {
            int kk=userManger.verification(act, pvd);
            if (kk > 0)
            {
                Session["ui"] = userManger.usinfo;
                if (Session["ReturnUrl"] == null)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    String sb=(String)Session["ReturnUrl"];
                    return new RedirectResult(sb);
                }
            }
            else
            {
                if (kk == 0)
                {
                    ViewBag.Message = "Your Password or Account is wrong!";
                }
                else
                {
                    ViewBag.Message = "Server problems，please tell zgx！";
                }
                return View();
            }

        }
        /// <summary>
        /// 这是一个默认的注册界面
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }
        /// <summary>
        /// 注册页面包括返回的页面
        /// </summary>
        /// <param name="name"></param>
        /// <param name="pw"></param>
        /// <param name="email"></param>
        /// <param name="stc"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Register(String name, String pw, String email, String stc)
        {
            if (stc == "1180")
            {
                int kk = userManger.register(new userInfo() { Name = name, pw = pw, email = email });
                if (kk == 1)
                {
                    loginInformationSigns = 1;
                    return RedirectToAction("Login");
                }
                else
                {
                    ViewBag.Message = "Server error, or is your user name is not the only!";
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "SecurityCode is Wrong,You can get it from zgx!";
                return View();
            }
        }
        //public ActionResult Verification ()
        //{
        //    return Response.Redirect("user/ index");
        //}
    }
}
