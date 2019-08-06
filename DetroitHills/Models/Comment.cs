using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        public string userName { get; set; }

        public int PostId { get; set; }

        public DateTime date { get; set; }
        [Required(ErrorMessage = "Leave a comment!")]
        public string text { get; set; }
    }
}