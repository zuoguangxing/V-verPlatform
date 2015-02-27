using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using V_verPlatform.Models.User;
using System.IO;
using System.Xml;

namespace V_verPlatform.Models.CommonUse
{
    public class EmailServer
    {
        /// <summary>
        /// 发送邮件的方法
        /// </summary>
        /// <param name="toMail">目的邮件地址</param>
        /// <param name="title">发送邮件的标题</param>
        /// <param name="content">发送邮件的内容</param>
        /// <param name="nc">发送邮件的内容</param>
        /// <param name="fromMail">发送邮件地址</param>
        public static bool SendMail(string toMail, string title, string content,string fromMail,NetworkCredential nc)
        {
            //声明一个可以用SmtpClient发送的邮件
            MailMessage mail = new MailMessage();
            //设置邮件的主题
            mail.Subject = title;
            //设置邮件的内容
            mail.Body = content.ToString();
            //设置邮件内容的编码
            mail.BodyEncoding = Encoding.Unicode;
            //设置邮件是否为html格式
            mail.IsBodyHtml = true;
            //设置邮件的优先级
            mail.Priority = MailPriority.High;
            //声明一个用来发送邮件的帐号
            MailAddress mailaddress = new MailAddress(fromMail);
            mail.From = mailaddress;
            //声明一个用来接收邮件的帐号
            MailAddress mailaddress_receive = new MailAddress(toMail);
            //将接收邮件的帐号添加到收件人的地址集合，因为可以同时将一封邮件发送给多人，所以这里使用集合类型来存储收件人地址。
            mail.To.Add(mailaddress_receive);
            //声明一个简单邮件传输协议用来发送邮件
            SmtpClient client = new SmtpClient();
            //设置发件主机的SMTP服务器.比如163的SMTP服务器是：smtp.163.com，不同的主机有不同的SMTP服务器，需要我们到发件邮箱中查询。
            client.Host ="smtp.v-ver.com";
            //设置SMTP事务的端口，这个也是要到发件邮箱中查询
            client.Port = 25;
            //设置发件邮箱账号的用户名和密码
            client.Credentials = nc;
            //开始发送
            try
            {
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static void SendRegisterMail(UserInfo us)
        {
             StreamReader srReadFile = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/somefile/RegisteredEmail.html"),System.Text.Encoding.UTF8);
             String content = srReadFile.ReadToEnd();
             
             srReadFile.Close();
             content.Replace("{username}",us.Name);
             content.Replace("{registratelink}",CommonData.MainSite+"/"+"User/"+"EmailVerifier?"+us.Name+"&"+us.pw+"&"+us.email);
             content.Replace("{time}", DateTime.Now.ToString());
             XmlDocument xmlDoc = new XmlDocument();  
             xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Config/EmailConfig.xml")); //加载xml  
            XmlNode FromEmail = xmlDoc.SelectSingleNode("xml/EmailRegister");
            String address = FromEmail.SelectSingleNode("Address").InnerText;
            String password = FromEmail.SelectSingleNode("Password").InnerText;
            SendMail(us.email, "来自V-ver世界树", content,address , new NetworkCredential(address, password));
        }
    }

}