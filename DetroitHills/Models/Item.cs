using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetroitHills.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        public string name { get; set; }

        public string price { get; set; }

        public string price_lng { get; set; }
    }
}