using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models;

namespace V_verPlatform.Controllers
{
    [VverAuthorize(Roles = "Admin,PowerManager,Guest,User", Users = "Guest")]
    public class novelController : Controller
    {
        //
        // GET: /novel/

        public ActionResult Index()
        {
            return View();
        }

    }
}
