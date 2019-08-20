using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class TourBL
    {
        public List<Tour> GetTour()
        {
            DB mDB = new DB();
            return mDB.TourDB.ToList();
        }

        public void AddConcert(Tour t)
        {
            DB mDB = new DB();
            mDB.TourDB.Add(t);
            mDB.SaveChanges();
        }

        public void EditConcert(Tour t)
        {
            DB mDB = new DB();
            mDB.Entry(t).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeleteConcert(Tour t)
        {
            int index = t.TourId;
            DB mDB = new DAL.DB();
            List<Tour> postList = mDB.TourDB.ToList();
            Tour tour = postList.Where(us => us.TourId == index).FirstOrDefault();
            mDB.TourDB.Remove(tour);
            mDB.SaveChanges();
        }
    }
}