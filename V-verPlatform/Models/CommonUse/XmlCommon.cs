using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace V_verPlatform.Models.CommonUse
{
    public class XmlCommon
    {
        static public XmlNode RetRegion()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(System.Web.HttpContext.Current.Server.MapPath("~/Config/ConmmonString.xml")); //加载xml  
            XmlNode node = xmlDoc.SelectSingleNode("xml/region");
            return node;
        }
    }
}