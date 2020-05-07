using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class GameMenu
    {

        public GameMenu(ref Game game)
        {
            Game.running = true;
            Render(ref game, false);
            
        }


        private void Render(ref Game game, bool actionError)
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

            switch (operation)
            {
                case "1":
                    CreateGame(ref game);
                    break;
                case "2":
                    ShowTop();
                    break;
                case "3":
                    LoadGame(ref game);
                    break;
                case "4":
                    Exit();
                    break;
                default:
                    if(Game.running) Render(ref game, true);
                    break;
            }

        }

        void CreateGame(ref Game game)
        {
            game = new Game(false);
        }

        void LoadGame(ref Game game)
        {
            game = new Game(true);
        }
        void ShowTop()
        {
            throw new NotImplementedException();
        }
        void Exit()
        {
            Console.Clear();

            Console.WriteLine("YOU LEFT THE GAME!");
            System.Threading.Thread.Sleep(2000);
            Game.running = false;
        }


    }
}
