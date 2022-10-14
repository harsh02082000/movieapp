using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BookMyShowData.MovieDAL;

namespace BookMyShowBussiness
{
    public class TheatreBLL
    {
        public class TheatreOperations
        {
            MovieDbContext db = null;
            public TheatreOperations(MovieDbContext db)
            {
                this.db = db;
            }

            public string AddTheatre(Theatre theatre)
            {
                db.theatres.Add(theatre);
                db.SaveChanges();
                return "Saved";
            }
            public string UpdateTheatre(Theatre theatre)
            {
                db.Entry(theatre).State = EntityState.Modified;
                db.SaveChanges();
                return "Updated";
            }
            public string DeleteTheatre(int theatreId)
            {
                Theatre theatreObj = db.theatres.Find(theatreId);
                db.Entry(theatreObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "Deleted";
            }
            public List<Theatre> ShowAllTheatres()
            {
                List<Theatre> theatrelist = db.theatres.ToList();
                return theatrelist;
            }
        }
    }
}
