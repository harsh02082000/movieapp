using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BookMyShowData.MovieDAL;

namespace BookMyShowBussiness
{
    public class ShowTimingBLL
    {
        public class ShowTimingOperations
        {
            MovieDbContext db = null;
            public ShowTimingOperations(MovieDbContext db)
            {
                this.db = db;
            }

            public string AddShowTiming(ShowTiming showTiming)
            {
                db.showTimings.Add(showTiming);
                db.SaveChanges();
                return "Saved";
            }
            public string UpdateShowTiming(ShowTiming showTiming)
            {
                db.Entry(showTiming).State = EntityState.Modified;
                db.SaveChanges();
                return "Updated";
            }
            public string DeleteShowTiming(int showtimingId)
            {
                ShowTiming showtimingObj = db.showTimings.Find(showtimingId);
                db.Entry(showtimingObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "Deleted";
            }
            public List<ShowTiming> ShowAllShowTimings()
            {
                List<ShowTiming> showtiminglist = db.showTimings.ToList();
                return showtiminglist;
            }
        }
    }
}
