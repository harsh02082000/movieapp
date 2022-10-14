using BookMyShowPresentation;
using System;

namespace BookMyShow
{
    public class Program
    {
        static void Main(string[] args)
        {
            bool logLoop = true;
            while (logLoop == true)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("-------Welcome to Book My Show------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1) Press 1 for Movie\n" +
                    "2) Press 2 for Theatre\n" +
"3) Press 3 for ShowTiming\n" +
                    "4) Press 4 to exit");

                    int logCase = int.Parse(Console.ReadLine());
                    switch (logCase)
                    {
                        case 1:
                            MoviePL moviePL = new MoviePL();
                            moviePL.MenuPL();


                            break;
                        case 2:
                            TheatrePL theatrePL = new TheatrePL();
                            theatrePL.MenuTheatrePL();
                            break;
                        case 3:
                            ShowTimingPL showtimingPL = new ShowTimingPL();
                            showtimingPL.MenuShowTimingPL();
                            break;
                        case 4:
                            break;

                    }
                    Console.Read();
                }

                catch (Exception ex)
                {
                    logLoop = true;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Try again...");
                    Console.WriteLine(ex.GetType().ToString());
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            //MoviePL moviePL = new MoviePL();
            //moviePL.MenuPL();
            //TheatrePL theatrePL = new TheatrePL();
            //theatrePL.AddTheatrePL();
        }
    }
}

