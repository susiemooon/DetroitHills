using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DetroitHills.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        public string name { get; set; }

        public string photo { get; set; }

        public string price { get; set; }

        public string price_lng { get; set; }

        [NotMapped]
        public HttpPostedFileBase upload { get; set; }
    }
}