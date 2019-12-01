using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class Tour
    {
        [Key]
        public int TourId { get; set; }

        public DateTime tourDate { get; set; }

        public string name { get; set; }

        public string place { get; set; }

        public string ticketLink { get; set; }
    }
}