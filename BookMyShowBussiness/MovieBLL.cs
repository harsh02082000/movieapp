using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using static BookMyShowData.MovieDAL;
using System.Collections.Generic;
using System.Linq;

namespace BookMyShowBussiness
{
    public class MovieBLL
    {
        public class MovieOperations
        {
            MovieDbContext db = null;
            public MovieOperations(MovieDbContext db)
            {
                this.db = db;
            }

            public string AddMovie(Movie movie)
            {
                db.movies.Add(movie);
                db.SaveChanges();
                return "Saved";
            }
            public string UpdateMovie(Movie movie)
            {
                db.Entry(movie).State = EntityState.Modified;
                db.SaveChanges();
                return "Updated";
            }
            public string DeleteMovie(int movieId)
            {
                Movie movieObj = db.movies.Find(movieId);
                db.Entry(movieObj).State = EntityState.Deleted;
                db.SaveChanges();
                return "Deleted";
            }
            public List<Movie> ShowAllMovies()
            {
                List<Movie> movielist = db.movies.ToList();
                return movielist;
            }
            public List<Movie> ShowAllByMovieType(string type)
            {
                List<Movie> movielist = db.movies.ToList();

                //Linq query - select * from movie where movietype='type'
                var result = from movies in movielist
                             where movies.MovieType == type
                             orderby movies.MovieType ascending
                             select movies;
                //{
                //    Id = movies.Id,
                //    Name = movies.Name,
                //};
                List<Movie> movieresult = new List<Movie>();
                foreach (var item in result)//linq query execution
                {
                    movieresult.Add(item);
                }
                return movieresult;
            }
            public Movie ShowMovieByid(int movieId)
            {
                Movie movie = db.movies.Find(movieId);
                return movie;
            }
        }
    }
}
