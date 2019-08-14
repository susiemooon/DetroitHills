using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

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
    }
}