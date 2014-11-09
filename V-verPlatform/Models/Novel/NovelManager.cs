using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V_verPlatform.Controllers;

namespace V_verPlatform.Models.Novel
{
    public class NovelManager
    {
        public List<NovelomitData> allList{get;set;}
        public NovelManager()
        {
            allList = RetList();
        }
        public List<NovelomitData> RetList()
        {
          return  NovelService.RetList();
        }
        public NovelData RetNovel(int ID)
        {
            return NovelService.RetNovel(ID);
        }
        public NovelData RetNovel(String title)
        {
            return NovelService.RetNovel(title);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateInput(false)]
        public int AddNovel(String novelText,String title,String classify)
        {
            try
            {
                if (NovelService.AddNovel(new NovelData(DateTime.Now, novelText, UserController.userManger.usinfo.ID, classify, title)))
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
            catch (Exception e)
            {
                return 1;
            }
        }
    }
}