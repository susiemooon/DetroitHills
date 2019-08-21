using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class PhotosBL
    {
        public List<Photo> GetPhotos()
        {
            DB mDB = new DB();
            return mDB.PhotoDB.ToList();
        }

        public void AddPhoto(Photo p)
        {
            DB mDB = new DB();
            mDB.PhotoDB.Add(p);
            mDB.SaveChanges();
        }

        public void EditPhoto(Photo p)
        {
            DB mDB = new DB();
            mDB.Entry(p).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeletePhoto(Photo p)
        {
            int index = p.PhotoId;
            DB mDB = new DAL.DB();
            List<Photo> photoList = mDB.PhotoDB.ToList();
            Photo photo = photoList.Where(us => us.PhotoId == index).FirstOrDefault();
            mDB.PhotoDB.Remove(photo);
            mDB.SaveChanges();
        }
    }
}