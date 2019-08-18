using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class PostBL
    {
        public List<Post> GetPosts()
        {
            DB mDB = new DB();
            return mDB.PostDB.ToList();
        }
    }
}