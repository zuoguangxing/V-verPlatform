using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using V_verPlatform.Models.DB;


namespace V_verPlatform.Models.Novel
{
    public class NovelService
    {
        static public List<NovelomitData> RetList()
        {
            List<NovelomitData> list = new List<NovelomitData>();
            SqlDataReader sqdr = SqlHelper.ExecuteReader(SqlHelper.conStr, CommandType.Text, "SELECT * FROM Vnovel ORDER BY ID DESC");
                while(sqdr.Read())
                {
                    list.Add(new NovelomitData((DateTime)sqdr["Date"], (int)sqdr["userID"], (String)sqdr["classify"], (String)sqdr["title"], (int)sqdr["ID"]));
                }
            sqdr.Close();
            return list;
        }
        static public List<NovelomitData> RetList(String classify)
        {
            List<NovelomitData> list = new List<NovelomitData>();
            SqlDataReader sqdr = SqlHelper.ExecuteReader(SqlHelper.conStr, CommandType.Text, "SELECT * FROM Vnovel ORDER BY ID DESC WHERE classify='"+classify+"'");
            while (sqdr.Read())
            {
                list.Add(new NovelomitData((DateTime)sqdr["Date"], (int)sqdr["userID"], (String)sqdr["classify"], (String)sqdr["title"], (int)sqdr["ID"]));
            }
            sqdr.Close();
            return list;
        }
        static public List<NovelomitData> RetList(int num)
        {
            List<NovelomitData> list = new List<NovelomitData>();
            SqlDataReader sqdr = SqlHelper.ExecuteReader(SqlHelper.conStr, CommandType.Text, "SELECT * FROM Vnovel ORDER BY ID DESC");
            for (int i = 0; i < num; i++)
            {
                if (sqdr.Read())
                {
                    list.Add(new NovelomitData((DateTime)sqdr["Date"], (int)sqdr["userID"], (String)sqdr["classify"], (String)sqdr["title"], (int)sqdr["ID"]));
                }
                else
                {
                    break;
                }
            }
            sqdr.Close();
            return list;
        }
        static public NovelData RetNovel(int ID)
        {
            NovelData nd;
            SqlDataReader sqdr = SqlHelper.ExecuteReader(SqlHelper.conStr, CommandType.Text, "SELECT * FROM Vnovel WHERE ID="+ID);
             if (sqdr.Read())
             {
                 nd = new NovelData((DateTime)sqdr["Date"], (String)sqdr["text"], (int)sqdr["userID"], (String)sqdr["classify"], (String)sqdr["title"], (int)sqdr["ID"]);
              }
             else
             {
              nd=null;
             }
            sqdr.Close();
            return nd;
        }
        static public NovelData RetNovel(String title)
        {
            NovelData nd;
            SqlDataReader sqdr = SqlHelper.ExecuteReader(SqlHelper.conStr, CommandType.Text, "SELECT * FROM Vnovel WHERE title='"+title+"'");
             if (sqdr.Read())
             {
             nd= new NovelData((DateTime)sqdr["Date"],(String)sqdr["text"],(int)sqdr["userID"], (String)sqdr["classify"], (String)sqdr["title"], (int)sqdr["ID"]);
              }
             else
             {
              nd=null;
             }
            sqdr.Close();
            return nd;
        }
        static public bool AddNovel(NovelData novel)
        {
            //try
            //{
            SqlHelper.ExecuteNonQuery(SqlHelper.conStr, CommandType.Text, "INSERT INTO novel (title,userID,classify,text,Date) VALUES('" + novel.title + "'," + novel.userID + ",'" + novel.classify + "','" + novel.text + "','" + novel.Date + "')");
            return true;
            //}
            //catch(Exception e)
            //{
            //    return false;
            //}
        }
    }
}