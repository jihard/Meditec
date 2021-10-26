using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryManager
{
    public class AppInstructions 
    {
        
        public static void Instructions()
        {
            Console.WriteLine("\b");
            Console.WriteLine($"\t\t========Welcome to home Library manager========");
            Console.WriteLine("\b");
            Console.WriteLine($"\tIn order to operate with this application you will have to use Option menu to navigate your work.\n" +
                $"\tBy selecting (2. Add books) - You will be able Fill your Library by adding each book.\n" +
                $"\tBy selecting (3. Display library list) - Displays all your Library content.\n" +
                $"\tBy selecting (4. Search books) - Application will search books by authors.\n" +
                $"\tBy selecting (5. Delete books) - Application will delete books from Library by selected name.\n" +
                $"\tBy selecting (6. Exit) - Application can be closed.");
            Options.DisplayOption();
            
        }
    }
}
