using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DetroitHills.Models;

namespace DetroitHills.DAL
{
    public class DB : DbContext
    {
        public DB() : base("dbDetroitHills")
        {

        }

        public DbSet<Comment> CommentDB { get; set; }
        public DbSet<Item> ItemDB { get; set; }
        public DbSet<Photo> PhotoDB { get; set; }
        public DbSet<Post> PostDB { get; set; }
        public DbSet<Tour> TourDB { get; set; }
        public DbSet<User> UserDB { get; set; }
        public DbSet<Video> VideoDB { get; set; }
        public DbSet<Order> OrderDB { get; set; }
    }
}