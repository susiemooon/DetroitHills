using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DetroitHills.DAL;


namespace DetroitHills.Models
{
    public class UserBL
    {
        public bool isValidUser(string userName, string password)
        {
            DB mDB = new DB();
            List<User> loginList = mDB.UserDB.ToList();

            User lg = loginList.Where(us => us.username == userName).SingleOrDefault();
            if (lg == null) { return false; }
            if ((userName == lg.username) && (password == lg.password))
            { return true; }

            return false;
        }

        public List<User> GetUsers()
        {
            DB mDB = new DB();
            return mDB.UserDB.ToList();
        }

        public void AddUser(User u)
        {
            DB mDB = new DB();
            List<User> users = mDB.UserDB.ToList();
            // TODO check if there is same username
            mDB.UserDB.Add(u);
            mDB.SaveChanges();
        }
    }
}