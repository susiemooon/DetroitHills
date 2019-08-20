using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class VideoBL
    {
        public List<Video> GetVideos()
        {
            DB mDB = new DB();
            return mDB.VideoDB.ToList();
        }

        public void AddVideo(Video v)
        {
            DB mDB = new DB();
            mDB.VideoDB.Add(v);
            mDB.SaveChanges();
        }

        public void EditVideo(Video v)
        {
            DB mDB = new DB();
            mDB.Entry(v).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeleteVideo(Video v)
        {
            int index = v.VideoId;
            DB mDB = new DAL.DB();
            List<Video> postList = mDB.VideoDB.ToList();
            Video video = postList.Where(us => us.VideoId == index).FirstOrDefault();
            mDB.VideoDB.Remove(video);
            mDB.SaveChanges();
        }
    }
}