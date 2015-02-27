using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using V_verPlatform.Models;
using V_verPlatform.Models.DB;
using V_verPlatform.Models.User;

namespace V_verPlatform.Controllers.api
{
    /// <summary>
    /// 接受Post请求，传入参数model为1为注册
    /// </summary>
    public class ApiUserController : ApiController
    {
        //// GET api/apiuser
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public class Date
        {
            public int model { get; set; }
            public String act { get; set; }
            public String pvd { get; set; }
            public String email { get; set; }
            public String stc { get; set; }
        }
        public HttpResponseMessage Post([FromBody]Date dt)
        {
            if (dt.model==0)
            {
            int kk = UserController.userManger.Verificatie(dt.act, dt.pvd);
            if (kk > 0)
            {
                return CommonUsed.toJson(UserController.userManger.usinfo);
            }
            else
            {
                if (kk == 0)
                {
                    return new HttpResponseMessage(HttpStatusCode.Forbidden);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            }
            else if(dt.model==1)
            {
                 if (dt.stc == "1180")
            {
                int kk = UserController.userManger.register(new UserInfo() { Name = dt.act, pw = dt.pvd, email = dt.email });
                if (kk == 1)
                {
                    return new HttpResponseMessage(HttpStatusCode.Created);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.Forbidden);
            }
        }
        //public HttpResponseMessage PostRegister(RegisterDate rd)
        //{
        //    if (rd.stc == "1180")
        //    {
        //        int kk = UserController.userManger.register(new userInfo() { Name = rd.name, pw = rd.pw, email = rd.email });
        //        if (kk == 1)
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.Created);
        //        }
        //        else
        //        {
        //            return new HttpResponseMessage(HttpStatusCode.InternalServerError);
        //        }
        //    }
        //    else
        //    {
        //        return new HttpResponseMessage(HttpStatusCode.Forbidden);
        //    }
        //}
        // GET api/apiuser/5
        //public string Get(int id)
        //{
        //    return "5";
        //}

        //// POST api/apiuser
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/apiuser/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/apiuser/5
        //public void Delete(int id)
        //{
        //}
    }
}
