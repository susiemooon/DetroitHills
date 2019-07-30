using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetroitHills.Models
{
    public class User
    {

        public int UserId { get; set; }

        public string username { get; set; }

        public string email { get; set; }

        public string password { get; set; }
    }
}