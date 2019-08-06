using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string title { get; set; }

        public string title_lng { get; set; }

        [Required]
        public string text { get; set; }

        public string text_lng { get; set; }

        public DateTime date { get; set; }



    }
}