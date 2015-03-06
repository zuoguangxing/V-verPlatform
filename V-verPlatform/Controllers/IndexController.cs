using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models.DB;
using V_verPlatform.Models;
using System.Data;
using V_verPlatform.Models.Module;
using V_verPlatform.Models.User;
namespace V_verPlatform.Controllers
{
    public class IndexController : Controller
    {
        //
        // GET: /Index/
        public ActionResult Index()
        {
            try
            {
                ViewBag.kfzList = KfzBj.RetList(5);
                ViewBag.LoadingMessage = "The Website is founded in HongKong";
                return View();
            }
            catch (Exception e)
            {
                return RedirectToAction("Admin", "User");
            }
        }
        public ActionResult Test(String name,String img1,String img2)
        {
            SqlHelper.ExecuteNonQuery(UserService.conStr, CommandType.Text, "INSERT INTO Table_1 (Name,img,img2) VALUES('"+name + "','" + img1 +"','"+img2+"')");
            return View();
        }
    }
}
