using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.Models;

namespace DetroitHills.ViewModels
{
    public class CommentsVM
    {
        public List<Comment> commentsList { get; set; }
        public Comment newComment { get; set; }
    }
}