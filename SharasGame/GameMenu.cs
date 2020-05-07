using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class GameMenu
    {

        public GameMenu(Game game)
        {

        }

        public string Run(bool actionError)
        {
            Console.Clear();

            Console.WriteLine("########## MAIN MENU ##########");
            Console.WriteLine("#                             #");
            Console.WriteLine("#      1. Start New Game      #");
            Console.WriteLine("#       2. Leader board       #");
            Console.WriteLine("#           3. Load           #");
            Console.WriteLine("#           4. Exit           #");
            Console.WriteLine("#                             #");
            Console.WriteLine("###############################");

            if (actionError)
            {
                Console.WriteLine();
                Console.WriteLine("Non-existent action.");
                Console.WriteLine();
            }
            Console.Write("Enter the action: ");
            string operation = Console.ReadLine();

            if( operation != "1" &&
                operation != "2" &&
                operation != "3" &&
                operation != "4")
            {
                return Run(true);
            }
            return operation;


        }



    }
}
