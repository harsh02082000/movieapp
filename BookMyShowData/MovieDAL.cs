using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;

namespace BookMyShowData
{
    public class MovieDAL
    {
        public class MovieDbContext : DbContext
        {
            public MovieDbContext()
            {
            }

            public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
            {

            }
            public DbSet<Movie> movies { get; set; }
            public DbSet<Theatre> theatres { get; set; }
            public DbSet<ShowTiming> showTimings { get; set; }
            public DbSet<User> users { get; set; }
            public DbSet<Location> locations { get; set; }
            public DbSet<Booking> bookings { get; set; }
            protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
            {
                dbContextOptionsBuilder.UseSqlServer("Data Source=VDC01LTC2159;Initial Catalog=BookMovieDb;Integrated Security=True;");
            }
        }
    }
}
