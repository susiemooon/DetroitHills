using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.Models;

namespace DetroitHills.ViewModels
{
    public class PhotosVM
    {
        public List<List<Photo>> albums { get; set; }
    }
}