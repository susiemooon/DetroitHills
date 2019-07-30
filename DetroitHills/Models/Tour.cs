using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DetroitHills.Models
{
    public class Tour
    {
        public int TourId { get; set; }

        public DateTime tourDate { get; set; }

        public string name { get; set; }

        public string place { get; set; }
    }
}