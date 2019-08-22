using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DetroitHills.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string username { get; set; }

        public string item { get; set; }

        public int amount { get; set; }

        public string adress { get; set; }

        public string phone { get; set; }

        public string size { get; set; }

        public string status { get; set; }

        public string status_lng { get; set; }
    }
}