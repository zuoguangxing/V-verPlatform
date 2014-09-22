using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models.DB;
namespace V_verPlatform.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        userDBEntities userdb = new userDBEntities();
        public ActionResult Index()
        {
            return View();
        }
    }
}
