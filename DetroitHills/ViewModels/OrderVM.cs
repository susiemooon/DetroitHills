using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.Models;

namespace DetroitHills.ViewModels
{
    public class OrderVM
    {
        public Item item { get; set; }
        public Order order { get; set; }
        
    }
}