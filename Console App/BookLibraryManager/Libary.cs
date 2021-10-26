using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryManager
{
    public class Libary : Books
    {
        static List<Books> LibraryList = new List<Books>();
        public static void AddLibrary()
        {
            string status = "yes";
            while (status == "yes")
            {
                Books book = new Books();
                Console.WriteLine("Book ID:{0}", book.bookId = LibraryList.Count + 1);
                Console.Write("Book name:");
                book.bookName = Console.ReadLine();
                Console.Write("Book author:");
                book.bookauthor = Console.ReadLine();
                LibraryList.Add(book);
                Console.WriteLine("==============================================");
                Console.WriteLine("enter 'yes' to continue, any key to save records ");
                status = Console.ReadLine();
            }
            Console.WriteLine("Your book are saved in library list");
        }

        public static void DisplayLibrary()
        {
            Console.WriteLine("========================");
            Console.WriteLine("MyLibrary list");
            Console.WriteLine("Book id      Book name        Book author");
            Console.WriteLine("=========    =========        ===========");
            foreach (var item in LibraryList.OrderBy(item => item.bookId))
                Console.WriteLine("{0}            {1}                {2}", item.bookId, item.bookName, item.bookauthor);
                Console.WriteLine();
        }

        public static void Searchbook()
        {
            Books book = new Books();
            Console.Write("Search by book author :");
            string findBook = (Console.ReadLine());

            if (LibraryList.Exists(item => item.bookauthor == findBook))
            {
                Console.WriteLine("========================");
                Console.WriteLine("Search results");
                Console.WriteLine("Book id      Book name        Book author");
                Console.WriteLine("=========    =========        ===========");
                foreach (Books searchItem in LibraryList)
                {
                    if (searchItem.bookauthor == findBook)
                    {
                       Console.WriteLine("{0}              {1}               {2}",searchItem.bookId, searchItem.bookName, searchItem.bookauthor);
                    }
                }
            }
            else
            {
                Console.WriteLine("Author {0} was not found", findBook);
            }
        }

        public static void DeleteBook()
        {
            string status = "yes";
            DisplayLibrary();
            while (status == "yes")
            {
                Console.Write("Select book name to delete :");
                string name = (Console.ReadLine());
                Books book = LibraryList.Find(item => item.bookName == name);

                if (book != null)
                {
                    LibraryList.Remove(book);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Book ({0}) was deleted!",name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There is no book by name ({0})",name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                DisplayLibrary();
                Console.WriteLine("enter 'yes' to continue, any key to finish delete records");
                status = Console.ReadLine();
                Console.WriteLine();
            } 
        }
    }
}
