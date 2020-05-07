using System;

namespace SharasGame
{
    public class Game
    {
        public bool running;
        public bool exit;
        public object activeWindow;
        public GameMenu menu;
        public GameMap map;
        public Player player;

        public Game()
        {
            running = false;
            exit = false;
            menu = new GameMenu(this);
            string op = menu.Run(false);
            ActOnMenuOperation(op);
            if (false) throw new NotImplementedException();
        }

        void ActOnMenuOperation(string operation)
        {
            switch (operation)
            {
                case "1":
                    CreateGame();
                    break;
                case "2":
                    ShowTop();
                    break;
                case "3":
                    LoadGame();
                    break;
                case "4":
                    Exit();
                    break;
            }
        }
        void ActOnGameOperation(string operation)
        {
            if(running && !exit)
            {
                if (operation.ToLower() == "w".ToLower() ||
                    operation.ToLower() == "up".ToLower())
                {
                    if (player.yPos > 0)
                    {
                        player.yPos--;
                        map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "s".ToLower() ||
                    operation.ToLower() == "down".ToLower())
                {
                    if (player.yPos < map.yLength() - 1)
                    {
                        player.yPos++;
                        map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "a".ToLower() ||
                    operation.ToLower() == "left".ToLower())
                {
                    if (player.xPos > 0)
                    {
                        player.xPos--;
                        map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "d".ToLower() ||
                    operation.ToLower() == "right".ToLower())
                {
                    if (player.xPos < map.xLength() - 1)
                    {
                        player.xPos++;
                        map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "exit".ToLower())
                {
                    Exit();
                }

            }
        }

        void CreateGame()
        {
            running = true;
            map = new GameMap(this);
            player = new Player(this);
            Loop();
        }

        void LoadGame()
        {
            throw new NotImplementedException();
        }
        void ShowTop()
        {
            throw new NotImplementedException();
        }
        void Exit()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("YOU LEFT THE GAME!");
            System.Threading.Thread.Sleep(2000);
            running = false;
            exit = true;    
        }

        public void Loop()
        {
            while (running && !exit)
            {
                string op = Render();
                Tick(op);
            }
        }
        public void Tick(string operation)
        {

            ActOnGameOperation(operation);

            /*
             Ops:
                 Down Up Left Right
                 Rest / Sleep
                 Quit
                 Save
             
             
             
             */
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