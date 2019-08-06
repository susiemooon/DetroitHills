using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace DetroitHills.Models
{
    public class Video
    {
        [Key]
        public int VideoId { get; set; }

        public string name { get; set; }

        public string link { get; set; }
    }
}