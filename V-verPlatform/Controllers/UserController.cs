using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models;

namespace V_verPlatform.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
        
        [VverAuthorize]
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Login()
        {
            
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        //public ActionResult Verification ()
        //{
        //    return Response.Redirect("user/ index");
        //}
    }
}
