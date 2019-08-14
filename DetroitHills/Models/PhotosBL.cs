using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class PhotosBL
    {
        public List<Photo> GetPhotos()
        {
            DB mDB = new DB();
            return mDB.PhotoDB.ToList();
        }
    }
}