using System;

namespace SharasGame
{
    public class Game
    {
        public static bool running;
        public object activeWindow;
        public GameMenu menu;
        public GameMap map;
        public Player player;

        public Game()
        {
            running = true;
            menu = new GameMenu();
            player = new Player();
            map = new GameMap();
            if (false) throw new NotImplementedException();
        }

        public void Loop()
        {
            while (running)
            {
                string op = Render();
                Tick(op);
            }
        }

        public void Tick(string operation)
        {
            /*
             Ops:
                 Down Up Left Right
                 Rest / Sleep
                 Quit
                 Save
             
             
             
             */
            throw new NotImplementedException();
        }
        public string Render()
        {
            Console.Clear();

            map.Render(player);
            Console.WriteLine();
            Console.Write("Fuck you wanna do B?: ");
            return Console.ReadLine();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}