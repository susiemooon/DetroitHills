using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;
using System.Data.Entity;

namespace DetroitHills.Models
{
    public class OrderBL
    {
        public List<Order> GetOrders()
        {
            DB mDB = new DB();
            return mDB.OrderDB.ToList();
        }

        public void AddOrder(Order p)
        {
            DB mDB = new DB();
            mDB.OrderDB.Add(p);
            mDB.SaveChanges();
        }

        public void EditOrder(Order p)
        {
            DB mDB = new DB();
            mDB.Entry(p).State = EntityState.Modified;
            mDB.SaveChanges();
        }

        public void DeleteOrder(Order p)
        {
            int index = p.OrderId;
            DB mDB = new DAL.DB();
            List<Order> orderList = mDB.OrderDB.ToList();
            Order order = orderList.Where(us => us.OrderId == index).FirstOrDefault();
            mDB.OrderDB.Remove(order);
            mDB.SaveChanges();
        }
    }
}