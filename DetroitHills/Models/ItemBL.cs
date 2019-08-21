using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class ItemBL
    {
        public List<Item> GetItems()
        {
            DB mDB = new DB();
            return mDB.ItemDB.ToList();
        }

        public void AddItem(Item p)
        {
            DB mDB = new DB();
            mDB.ItemDB.Add(p);
            mDB.SaveChanges();
        }

        public void EditItem(Item p)
        {
            DB mDB = new DB();
            mDB.Entry(p).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeleteItem(Item p)
        {
            int index = p.ItemId;
            DB mDB = new DAL.DB();
            List<Item> postList = mDB.ItemDB.ToList();
            Item item = postList.Where(us => us.ItemId == index).FirstOrDefault();
            mDB.ItemDB.Remove(item);
            mDB.SaveChanges();
        }
    }
}