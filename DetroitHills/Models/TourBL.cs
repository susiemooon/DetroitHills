using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class TourBL
    {
        public List<Tour> GetTour()
        {
            DB mDB = new DB();
            return mDB.TourDB.ToList();
        }
    }
}