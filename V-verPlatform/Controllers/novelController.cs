using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Models;
using V_verPlatform.Models.Novel;
using Webdiyer.WebControls.Mvc;

namespace V_verPlatform.Controllers
{
    public class novelController : Controller
    {
        //
        // GET: /novel/
        public NovelManager NM = new NovelManager();
        public ActionResult Index(int pi = 1,int ps=8)
        {
            ////用户
            ////信息列表(此处使用分页控件提出数据)
            //int totalCount = 0;
            int pageIndex = pi;
            int pageSize = ps;
            List<NovelomitData> lala = NM.allList;
            var model = lala.AsQueryable().ToPagedList(pageIndex, pageSize);
            if (Request.IsAjaxRequest())
                return PartialView("_NovelList", model);
            ViewBag.newNovel = NM.RetNovel(lala[0].ID);
            return View(model);
        }
        [VverAuthorize(Roles = "Admin,PowerManager",Users="On")]
        public ActionResult Manager()
        {
            ////用户
            ////信息列表(此处使用分页控件提出数据)
            //int totalCount = 0;
            return PartialView("_NovelManager");
        }
        [VverAuthorize(Roles = "Admin,PowerManager")]
        public int AddNovel(String novelText,String title,String classify)
        {
            ////用户
            ////信息列表(此处使用分页控件提出数据)
            //int totalCount = 0;
            if (NM.AddNovel(novelText, title, classify) == 0)
            {
                return 201;
            }
            else 
            {
                return 500;
            }
        }
    }
}
