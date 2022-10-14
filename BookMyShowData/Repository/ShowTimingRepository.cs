using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BookMyShowData.MovieDAL;

namespace BookMyShowData.Repository
{
    public class ShowTimingRepository: IShowTimingRepository
    {
        MovieDbContext _movieDbContext;
        public ShowTimingRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.showTimings.Add(showTiming);
            _movieDbContext.SaveChanges();
        }
        public void DeleteShowTiming(int showtimingId)
        {
            var showtiming = _movieDbContext.showTimings.Find(showtimingId);
            _movieDbContext.showTimings.Remove(showtiming);
            _movieDbContext.SaveChanges();
        }
      
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _movieDbContext.showTimings.Include(obj=>obj.Movie).ToList();
        }
        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _movieDbContext.Entry(showTiming).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
        public ShowTiming GetShowTimingById(int showTimingId)
        {
            return _movieDbContext.showTimings.Find(showTimingId);
        }
    }
}
