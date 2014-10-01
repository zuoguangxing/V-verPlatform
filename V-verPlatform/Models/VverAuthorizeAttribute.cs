using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace V_verPlatform.Models
{
    public class VverAuthorizeAttribute:AuthorizeAttribute
    {
//   代码顺序为：OnAuthorization-->AuthorizeCore-->HandleUnauthorizedRequest
//如果AuthorizeCore返回false时，才会走HandleUnauthorizedRequest 方法，并且Request.StausCode会返回401，401错误又对应了Web.config中
//的
//<authentication mode="Forms">
//      <forms loginUrl="~/" timeout="2880" />
//    </authentication>
//所有，AuthorizeCore==false 时，会跳转到 web.config 中定义的  loginUrl="~/"
    }
}