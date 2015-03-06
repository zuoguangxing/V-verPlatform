using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models.User;
using V_verPlatform.Models.DB;
using V_verPlatform.Models.CommonUse;
using System.Web.UI.WebControls;
using System.Net;
namespace V_verPlatform.Controllers
{
    public class UserController : Controller
    {
        static String AdminPvd = "1160";
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
            int kk=userManger.Verificatie(act, pvd);
            if (kk > 0)
            {
                Session["ui"] = userManger.usinfo;
                //验证e-mail是否验证
                if (userManger.usinfo.status != 0)
                {
                    ViewBag.Message = "Your account is in the abnormal state";
                    return View();
                }
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
                UserInfo usus =  new UserInfo() { Name = name, pw = pw, email = email,regdate= DateTime.Now,power=1,status=0 };
                int kk = userManger.register(usus);
                if (kk == 1)
                {
                    loginInformationSigns = 1;
                    EmailServer.SendRegisterMail(usus);
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
        [HttpPost]
        public ActionResult Admin(String pvd, int action=0)
        {
            if(action ==0)
            {
            if (pvd.Equals(AdminPvd))
            {
                ViewBag.AdminVerification = true;
                ViewBag.pvd = pvd;
                return View("AdminControl");
            }
            else
            {
                ViewBag.AdminVerification = false;
                return RedirectToAction("Admin");
            }
            }
            if (pvd.Equals(AdminPvd))
            {
                switch (action)
                {
                    case 1 :
                        {
                            if (AdminDBHelper.InitializeDatabase())
                            {
                                return new ContentResult() {Content="201"};
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
                return new ContentResult() {Content="400"};
            }
            else
            {
                return new ContentResult() { Content = "403" };
            }
        }
        public ActionResult Admin()
        {
            return View();
        }
    }
}
