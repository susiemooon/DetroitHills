using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class PostBL
    {
        public List<Post> GetPosts()
        {
            DB mDB = new DB();
            return mDB.PostDB.ToList();
        }

        public void AddPost(Post p)
        {
            DB mDB = new DB();
            mDB.PostDB.Add(p);
            mDB.SaveChanges();
        }

        public void EditPost(Post p)
        {
            DB mDB = new DB();
            mDB.Entry(p).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeletePost(Post p)
        {
            int index = p.PostId;
            DB mDB = new DAL.DB();
            List<Post> postList = mDB.PostDB.ToList();
            Post post = postList.Where(us => us.PostId == index).FirstOrDefault();
            mDB.PostDB.Remove(post);
            mDB.SaveChanges();
        }
    }
}