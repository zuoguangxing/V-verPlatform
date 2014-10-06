using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models.DB;
using V_verPlatform.Models;
using System.Data;
namespace V_verPlatform.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            ViewBag.LoadingMessage = "The Website is founded in HongKong";
            return View();
        }
        public ActionResult Test()
        {
            
            return View();
        }
    }
}
