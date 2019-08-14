using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;

namespace DetroitHills.Models
{
    public class ItemBL
    {
        public List<Item> GetItems()
        {
            DB mDB = new DB();
            return mDB.ItemDB.ToList();
        }
    }
}