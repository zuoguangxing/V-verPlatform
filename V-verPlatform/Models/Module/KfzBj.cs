using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using V_verPlatform.Models.DB;


namespace V_verPlatform.Models.Module
{
    //用来处理开发者笔记模块的内容
    public class KfzBj
    {
        static public String conStr = ConfigurationManager.ConnectionStrings["vverDB"].ConnectionString;
        static public List<KfzBjDate> RetList(int num)
        {
            List<KfzBjDate> list = new List<KfzBjDate>();
            SqlDataReader sqdr = SqlHelper.ExecuteReader(conStr, CommandType.Text, "SELECT * FROM kfzBJ ORDER BY noteID DESC");
            for (int i = 0; i < num; i++)
            {
                if (sqdr.Read())
                {
                    list.Add(new KfzBjDate((int)sqdr["userID"],(String)sqdr["kfzName"],(String)sqdr["note"],(DateTime)sqdr["Date"],(int)sqdr["noteID"]));
                }
                else 
                {
                    break;
                }
            }
            sqdr.Close();
            return list;
        }
        public bool addNote(KfzBjDate kbd)
        {
            try
            {
    //                noteID int NOT NULL IDENTITY (1, 1),
    //note ntext NOT NULL,
    //kfzName nchar(20) NOT NULL,
    //userID int NOT NULL,
    //Date datetime NOT NULL
    //)  ON [PRIMARY]
    // TEXTIMAGE_ON [PRIMARY]
                SqlHelper.ExecuteNonQuery(conStr, CommandType.Text, "INSERT INTO kfzBJ (kfzName,note,userID,Date) VALUES('" + kbd.kfzName + "','" + kbd.note + "'," + kbd.noteID + ",'" + kbd.datetime + "')");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    /// <summary>
    /// 用来储存开发者笔记信息
    /// </summary>
    public class KfzBjDate
    {
        public KfzBjDate(int userID,String kfzName,String note,DateTime datetime)
        {
            this.datetime = datetime;
            this.kfzName = kfzName;
            this.note = note;
            this.userID = userID;
        }
        public KfzBjDate(int userID, String kfzName, String note, DateTime datetime,int noteID)
        {
            this.datetime = datetime;
            this.kfzName = kfzName;
            this.note = note;
            this.userID = userID;
            this.userID = noteID;
        }
        public DateTime datetime;
        public String kfzName;
        public String note;
        public int userID;
        public int noteID = 0;
    }
}