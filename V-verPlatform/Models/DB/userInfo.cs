using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V_verPlatform.Models.DB
{
    using System;
    using System.Collections.Generic;

    public partial class userInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string pw { get; set; }
        public string email { get; set; }
        public byte power { get; set; }
    }
}