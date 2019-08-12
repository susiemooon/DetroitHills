using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class VideoBL
    {
        public List<Video> GetVideos()
        {
            DB mDB = new DB();
            return mDB.VideoDB.ToList();
        }
    }
}