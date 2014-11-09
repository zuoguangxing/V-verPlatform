using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using V_verPlatform.Models.DB;

namespace V_verPlatform.Models.Novel
{
    public class NovelData
    {
        [Display(Name = "小说ID")]
        public int ID { get; set; }
        [Display(Name = "发布时间")]
        public DateTime Date { get; set; }
        [Display(Name = "作者ID")]
        public int userID { get; set; }
        [Display(Name="小说内容")]
        public String text { get; set; }
        [Display(Name = "标题")]
        public String title { get; set; }
        [Display(Name = "卷宗")]
        public String classify { get; set; }
        public NovelData(DateTime datetime,String text, int userID, String classify, String title, int ID = 1180)
        {
            this.ID=ID;
            this.text = text;
            this.classify = classify;
            this.title = title;
            this.userID = userID;
            this.Date = datetime;
        }
    }
    public class NovelomitData
    {
        [Display(Name = "小说ID")]
        public int ID { get; set; }
        [Display(Name = "发布时间")]
        public DateTime Date { get; set; }
        [Display(Name = "作者ID")]
        public int userID { get; set; }
        [Display(Name = "标题")]
        public String title { get; set; }
        [Display(Name = "卷宗")]
        public String classify { get; set; }
        public NovelomitData(DateTime datetime, int userID, String classify, String title, int ID)
        {
            this.ID=ID;
            this.classify = classify;
            this.title = title;
            this.userID = userID;
            this.Date = datetime;
        }
    }
    //public class NovelDataSever
    //{
    //    public NovelData SingNovel(int ID)
    //    {
    //        SqlHelper.ExecuteReader(
    //    }
    //}
}