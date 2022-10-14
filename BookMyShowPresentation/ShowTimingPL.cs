using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;
using static BookMyShowBussiness.ShowTimingBLL;
using static BookMyShowBussiness.TheatreBLL;

namespace BookMyShowPresentation
{
    public class ShowTimingPL
    {
        public void MenuShowTimingPL()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Book My Show");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 1 to Add Show Timing\n" +
                "Enter 2 to Update Show Timing \n" +
                "Enter 3 to Delete Show Timing \n" +
                "Enter 4 to Show All Show Timing \n" +
                "Enter  to Exit"
                );
            int enter = Convert.ToInt32(Console.ReadLine());
            ShowTimingPL showtimingPLObj = new ShowTimingPL();
            switch (enter)
            {
                case 1:
                    showtimingPLObj.AddShowPL();
                    showtimingPLObj.MenuShowTimingPL();
                    break;
                case 2:
                    showtimingPLObj.UpdateShowTime();
                    showtimingPLObj.MenuShowTimingPL();
                    break;
                case 3:
                    showtimingPLObj.DeleteShowPL();
                    showtimingPLObj.MenuShowTimingPL();
                    break;
                case 4:
                    showtimingPLObj.ShowAllTimes();
                    showtimingPLObj.MenuShowTimingPL();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Better Luck Next Time :)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void AddShowPL()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            ShowTiming showTiming = new ShowTiming();
            Console.Write("Enter Movie Id: ");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id: "); ;
            showTiming.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Show Timings: ");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showTimingOperations.AddShowTiming(showTiming);
            Console.WriteLine(msg);
            MenuShowTimingPL();
        }
        public void DeleteShowPL()
        {
            Console.Write("Enter Show Id: ");
            int Id = Convert.ToInt32(Console.ReadLine());
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            string msg = showTimingOperations.DeleteShowTiming(Id);
            Console.WriteLine(msg);
            MenuShowTimingPL();
        }
        public void ShowAllTimes()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            List<ShowTiming> showTimings = showTimingOperations.ShowAllShowTimings();
            foreach (var item in showTimings)
            {
                Console.WriteLine("Show Id: " + item.Id);
                Console.WriteLine("Movie Id: " + item.MovieId);
                Console.WriteLine("Theatre id: " + item.Id);
                Console.WriteLine("Show Time: " + item.ShowTime);
            }
            MenuShowTimingPL();
        }
        public void UpdateShowTime()
        {
            ShowTimingOperations showTimingOperations = new ShowTimingOperations();
            ShowTiming showTiming = new ShowTiming();
            Console.WriteLine("Enter Show Id: ");
            showTiming.Id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Movie Id: ");
            showTiming.MovieId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Theatre Id: "); ;
            showTiming.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Show Timings: ");
            showTiming.ShowTime = Convert.ToDateTime(Console.ReadLine());
            string msg = showTimingOperations.UpdateShowTiming(showTiming);
            Console.WriteLine(msg);
            MenuShowTimingPL();
        }
    }
}
