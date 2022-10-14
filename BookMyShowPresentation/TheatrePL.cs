using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;
using static BookMyShowBussiness.MovieBLL;
using static BookMyShowBussiness.TheatreBLL;


namespace BookMyShowPresentation
{
    public class TheatrePL
    {
        public void MenuTheatrePL()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Welcome to Book My Show");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter 1 to Add Theatre\n" +
                "Enter 2 to Update Theatre \n" +
                "Enter 3 to Delete Theatre \n" +
                "Enter 4 to Show All Theatre \n" +
                "Enter  to Exit"
                );
            int enter = Convert.ToInt32(Console.ReadLine());
            TheatrePL theatrePLObj = new TheatrePL();
            switch (enter)
            {
                case 1:
                    theatrePLObj.AddTheatrePL();
                    theatrePLObj.MenuTheatrePL();
                    break;
                case 2:
                    theatrePLObj.UpdateTheatrePL();
                    theatrePLObj.MenuTheatrePL();
                    break;
                case 3:
                    theatrePLObj.DeleteTheatrePL();
                    theatrePLObj.MenuTheatrePL();
                    break;
                case 4:
                    theatrePLObj.ShowAllTheatresPL();
                    theatrePLObj.MenuTheatrePL();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Better Luck Next Time :)");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        public void AddTheatrePL()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            Theatre theatres = new Theatre();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Enter TheatreName: ");
            theatres.Name = Console.ReadLine();
            Console.Write("Enter Theatre Address: ");
            theatres.Address = Console.ReadLine();
            Console.Write("Enter Theatre Comment: ");
            theatres.Comments = Console.ReadLine();
            string msg = theatreOperations.AddTheatre(theatres);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void ShowAllTheatresPL()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            Console.ForegroundColor = ConsoleColor.Magenta;
            List<Theatre> theatres = theatreOperations.ShowAllTheatres();
            foreach (var item in theatres)
            {
                Console.WriteLine("Id: " + item.Id);
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Address: " + item.Address);
                Console.WriteLine("Comment: " + item.Comments);
            }
        }
        public void DeleteTheatrePL()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            Console.Write("Enter Theatre Id: ");
            int theatreId = Convert.ToInt32(Console.ReadLine());
            string msg = theatreOperations.DeleteTheatre(theatreId);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }
        public void UpdateTheatrePL()
        {
            TheatreOperations theatreOperations = new TheatreOperations();
            Theatre theatreObj = new Theatre();
            Console.WriteLine("Enter TheatreId: ");
            theatreObj.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter TheatreName: ");
            theatreObj.Name = Console.ReadLine();
            Console.WriteLine("Enter Theatre Address: ");
            theatreObj.Address = Console.ReadLine();
            Console.WriteLine("Enter Comments: ");
            theatreObj.Comments = Console.ReadLine();
            string msg = theatreOperations.UpdateTheatre(theatreObj);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(msg);
        }
    }
}
