using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class Photo
    {
        [Key]
        public int PhotoId { get; set; }

        public string photoalbum { get; set; }

        public string path { get; set; }
    }
}