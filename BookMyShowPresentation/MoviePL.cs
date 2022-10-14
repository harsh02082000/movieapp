using BookMyShowEntity;
using System;
using static BookMyShowBussiness.MovieBLL;
using System.Collections.Generic;

namespace BookMyShowPresentation
{
    public class MoviePL
    {
        public void MenuPL()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Book My Show");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 1 to Add Movie \n" +
                "Enter 2 to Update Movie \n" +
                "Enter 3 to Delete Movie \n" +
                "Enter 4 to Show All Movie \n" +
                "Enter 5 to Show Movie By Id \n" +
                "Enter 6 to Show Movie By Type\n" +
                "Enter  to Exit"
                );
            int enter = Convert.ToInt32(Console.ReadLine());
            MoviePL moviePLObj = new MoviePL();
            switch (enter)
            {
                case 1:
                    moviePLObj.AddMoviePL();
                    moviePLObj.MenuPL();
                    break;
                case 2:
                    moviePLObj.UpdateMoviePL();
                    moviePLObj.MenuPL();
                    break;
                case 3:
                    moviePLObj.DeleteMoviePL();
                    moviePLObj.MenuPL();
                    break;
                case 4:
                    moviePLObj.ShowAllMoviesPL();
                    moviePLObj.MenuPL();
                    break;
                case 5:
                    moviePLObj.ShowMovieByIdPL();
                    moviePLObj.MenuPL();
                    break;
                case 6:
                    moviePLObj.ShowAllByMovieTypePL();
                    moviePLObj.MenuPL();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Better Luck Next Time :)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void AddMoviePL()
        {
            MovieOperations movieOperations = new MovieOperations();
            Movie movie = new Movie();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter MovieName: ");
            movie.Name = Console.ReadLine();
            Console.Write("Enter Movie Description: ");
            movie.MovieDesc = Console.ReadLine();
            Console.Write("Enter Movie Type: ");
            movie.MovieType = Console.ReadLine();
            string msg = movieOperations.AddMovie(movie);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAllMoviesPL()
        {
            MovieOperations movieOperations = new MovieOperations();
            Console.ForegroundColor = ConsoleColor.Magenta;
            List<Movie> movies = movieOperations.ShowAllMovies();
            foreach (var item in movies)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Description: " + item.MovieDesc);
                Console.WriteLine("Type: " + item.MovieType);
            }
        }
        public void DeleteMoviePL()
        {
            MovieOperations movieOperations = new MovieOperations();
            Console.Write("Enter MovieId: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            string msg = movieOperations.DeleteMovie(movieId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }
        public void UpdateMoviePL()
        {
            MovieOperations movieOperationsObj = new MovieOperations();
            Movie movieObj = new Movie();
            Console.WriteLine("Enter MovieId: ");
            movieObj.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter MovieName: ");
            movieObj.Name = Console.ReadLine();
            Console.WriteLine("Enter Movie Description: ");
            movieObj.MovieDesc = Console.ReadLine();
            Console.WriteLine("Enter Movie Type: ");
            movieObj.MovieType = Console.ReadLine();
            string msg = movieOperationsObj.UpdateMovie(movieObj);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }
        public void ShowMovieByIdPL()
        {
            MovieOperations movieOperationsObj = new MovieOperations();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter MovieId: ");
            int movieId = Convert.ToInt32(Console.ReadLine());
            Movie movie = movieOperationsObj.ShowMovieByid(movieId);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Movie Name: " + movie.Name);
            Console.WriteLine("Movie Description: " + movie.MovieDesc);
            Console.WriteLine("Movie Type: " + movie.MovieType);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAllByMovieTypePL()
        {
            MovieOperations movieOperationsObj = new MovieOperations();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Enter Movie Type: ");
            string movieType = Console.ReadLine();
            List<Movie> movie = movieOperationsObj.ShowAllByMovieType(movieType);
            foreach (var item in movie)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Movie Id: " + item.Id);
                Console.WriteLine("Movie Name: " + item.Name);
                Console.WriteLine("Movie Description: " + item.MovieDesc);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}

