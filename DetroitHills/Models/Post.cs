using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetroitHills.Models
{
    public class Post
    {
        public int PostId { get; set; }

        public string title { get; set; }

        public string title_lng { get; set; }

        public string text { get; set; }

        public string text_lng { get; set; }

        public DateTime date { get; set; }



    }
}