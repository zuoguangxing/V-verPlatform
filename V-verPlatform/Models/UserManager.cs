using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using V_verPlatform.Models.DB;
namespace V_verPlatform.Models
{
    public class UserManager
    {
        UserService us=new UserService();
        public int AddUser(userInfo user)
        {
            return us.AddUser(user);
        }
    }
}