using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace V_verPlatform.Models.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class userInfo
    {

        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string pw { get; set; }
        [Required]
        public string email { get; set; }
        public byte power { get; set; }
    }
}