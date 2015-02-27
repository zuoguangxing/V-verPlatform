using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace V_verPlatform.Models.User
{
    public partial class UserInfo
    {
        public enum UserStatus
        {
            Normal,
            Unverified,
            Illegal
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public string pw { get; set; }
        public string email { get; set; }
        public byte power { get; set; }
        public DateTime regdate { get; set; }
        public UserStatus status { get; set; }
    }
}