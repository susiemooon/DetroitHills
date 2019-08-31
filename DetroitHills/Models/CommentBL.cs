using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class CommentBL
    {
        public List<Comment> GetComments()
        {
            DB mDB = new DB();
            return mDB.CommentDB.ToList();
        }

        public void AddComment(Comment c)
        {
            DB mDB = new DB();
            mDB.CommentDB.Add(c);
            mDB.SaveChanges();
        }

        public void EditComment(Comment p)
        {
            DB mDB = new DB();
            mDB.Entry(p).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeleteComment(Comment p)
        {
            int index = p.CommentId;
            DB mDB = new DAL.DB();
            List<Comment> comList = mDB.CommentDB.ToList();
            Comment comment = comList.Where(us => us.CommentId == index).FirstOrDefault();
            mDB.CommentDB.Remove(comment);
            mDB.SaveChanges();
        }

        public List<Comment> FindComments(int postId)
        {
            DB mDB = new DB();
            List<Comment> tmp = mDB.CommentDB.ToList();
            List<Comment> comList = new List<Models.Comment>();
            foreach (Comment c in tmp)
            {
                if (c.PostId == postId)
                    comList.Add(c);
            }

            return comList;
        }
    }
}