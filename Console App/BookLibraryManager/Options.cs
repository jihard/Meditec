using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryManager
{
    public class Options
    {

        public static void Authorization()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = Menu();
            }
        }

        public static bool Menu()
        {
            Console.Clear();
            Console.WriteLine("\b");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\t\t+++++++ Home Library +++++++");
            Console.WriteLine("\b");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tChoose an option:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t1) Instructions");
            Console.WriteLine("\t2) Add books");
            Console.WriteLine("\t3) Display library list");
            Console.WriteLine("\t4) Search books");
            Console.WriteLine("\t5) Delete books");
            Console.WriteLine("\t6) Exit");

            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AppInstructions.Instructions();
                    return true;
                case "2":
                    Libary.AddLibrary();
                    DisplayOption();
                    return true;
                case "3":
                    Libary.DisplayLibrary();
                    DisplayOption();
                    return true;
                case "4":
                    Libary.Searchbook();
                    DisplayOption();
                    return true;
                case "5":
                    Libary.DeleteBook();
                    DisplayOption();
                    return true;
                case "6":
                    Console.Clear();
                    Console.WriteLine("See you next time");
                    return false;
                default:
                    return true;
            }
        }

        public static void DisplayOption()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\r\nPress Enter to return to Main Menu");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
    }
}
