using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.Models;

namespace DetroitHills.ViewModels
{
    public class CreatePostVM
    {
        public Post p { get; set; }
        public HttpPostedFileBase upload { get; set; }
    }
}