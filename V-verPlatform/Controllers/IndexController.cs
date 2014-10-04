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
        public static UserManager userManger = new UserManager();
        public ActionResult Index()
        {
            return View();
        }
        public String test()
        {
            //DataSet wangji = SqlHelper.ExecuteDataset(UserService.conStr, CommandType.Text, "SELECT * FROM UserNP");
            //DataTable table =wangji.Tables[0];
            //DataRowCollection rows = table.Rows;
            //DataRow row =rows[0];
            //return (String)row["Name"];
            return userManger.verification("wangji", "1180").ToString();
        }
    }
}
