using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SharasGame
{
    public class Game
    {
        public bool inGame;
        public bool exit;
        public object activeWindow;
        public GameMenu menu;
        public GameMap map;
        public Player player;

        public Game()
        {
            inGame = false;
            exit = false;
            menu = new GameMenu(this);
            Loop();

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
                    Load();
                    break;
                case "4":
                    ExitProgram();
                    break;
            }
        }
        bool ActOnGameOperation(string operation)
        {
            bool alive = true;

            if (inGame && !exit)
            {
                if (operation.ToLower() == "w".ToLower() ||
                    operation.ToLower() == "up".ToLower())
                {
                    if (player.yPos > 0)
                    {
                        player.yPos--;
                        alive = map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "s".ToLower() ||
                    operation.ToLower() == "down".ToLower())
                {
                    if (player.yPos < map.yLength() - 1)
                    {
                        player.yPos++;
                        alive = map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "a".ToLower() ||
                    operation.ToLower() == "left".ToLower())
                {
                    if (player.xPos > 0)
                    {
                        player.xPos--;
                        alive = map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "d".ToLower() ||
                    operation.ToLower() == "right".ToLower())
                {
                    if (player.xPos < map.xLength() - 1)
                    {
                        player.xPos++;
                        alive = map.ReactToStep(player);
                    }
                }
                if (operation.ToLower() == "rest".ToLower())
                {
                    player.Rest();
                    player.addTurn();
                    player.AdjustForDeficencies();
                    if (!player.isAlive()) OnDeath();
                }
                if (operation.ToLower() == "exit".ToLower())
                {
                    ExitGame();
                }
                if (operation.ToLower() == "save".ToLower())
                {
                    Save();
                }
            }
            return alive;
        }
        void CreateGame()
        {
            inGame = true;
            map = new GameMap(this);
            player = new Player(this);
        }
        void ShowTop()
        {
            Console.Clear();
            string topPath = "TopList.txt";
            if (!File.Exists(topPath))
            {
                Console.WriteLine("Leaderboard is empty!");
                System.Threading.Thread.Sleep(2000);
                return;
            }
            StreamReader sr = new StreamReader(topPath);
            List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] args = line.Split(';');
                list.Add(new KeyValuePair<string, int>(args[0], int.Parse(args[1])));
            }
            if(list.Count == 0)
            {
                Console.WriteLine("Leaderboard is empty!");
                System.Threading.Thread.Sleep(2000);
                sr.Close();
                return;
            }
            list.Sort((x, y) => y.Value.CompareTo(x.Value));
            int place = 1;
            foreach (var dude in list)
            {
                Console.WriteLine($@"{place}. {dude.Key} - {dude.Value}");
                //1. Name - Score
                place++;
            }
            sr.Close();
            System.Threading.Thread.Sleep(5000);
        }
        void ExitProgram()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("YOU LEFT THE GAME!");
            System.Threading.Thread.Sleep(2000);
            inGame = false;
            exit = true;    
        }
        void ExitGame()
        {
            inGame = false; 
        }
        public void Loop()
        {
            while (!exit)
            {
                if (inGame)
                {
                    string op = Render();
                    Tick(op);
                }
                else
                {
                    string op = menu.Run(false);
                    ActOnMenuOperation(op);
                }
            }
        }
        public void Tick(string operation)
        {
            bool alive = ActOnGameOperation(operation);
            if (!alive)
            {
                OnDeath();
            }
        }
        private void OnDeath()
        {
            inGame = false;
            Console.Clear();
            Console.WriteLine("You died!");
            System.Threading.Thread.Sleep(2000);
        }
        public void OnVictory()
        {
            int score = player.getScore();
            Console.Clear();
            Console.WriteLine("You won!");
            Console.WriteLine($@"Final score: {score} ");
            Console.WriteLine();
            Console.Write("Enter your name for leaderboards: ");
            string name = Console.ReadLine();
            name = Regex.Replace(name, ";", "");
            PostToTopList(name, score);
            inGame = false;
            System.Threading.Thread.Sleep(4000);
        }
        private void PostToTopList(string name, int score)
        {
            string topListPath = "TopList.txt";
            if (!File.Exists(topListPath)) File.Create(topListPath);
            System.Threading.Thread.Sleep(50);
            StreamReader sr = new StreamReader(topListPath);
            string data = sr.ReadToEnd();
            string newData = $"{name};{score}\n";
            sr.Close();

            StreamWriter sw = new StreamWriter(topListPath);
            sw.Write(data + newData);
            sw.Close();
        }
        public string Render(string message = "")
        {
            Console.Clear();

            map.Render(player);
            player.RenderStats();
            Console.WriteLine(message);
            Console.Write("What's your next move?: ");
            return Console.ReadLine();
        }
        public void Save()
        {
            string savedPath = "saved.txt";
            StreamWriter sw = new StreamWriter(savedPath);
            string mapTilesLine = "";

            for(int i = 0; i < map.yLength(); i++)
            {
                for (int j = 0; j < map.xLength(); j++)
                {
                    mapTilesLine += map.tiles[i, j].symbol;
                }
            }

            sw.WriteLine(mapTilesLine);
            sw.WriteLine(player.xPos);
            sw.WriteLine(player.yPos);
            sw.WriteLine(player.Name);
            sw.WriteLine(player.Turns);
            sw.WriteLine(player.HP);
            sw.WriteLine(player.maxHP);
            sw.WriteLine(player.Energy);
            sw.WriteLine(player.maxEnergy);
            sw.WriteLine(player.Food);
            sw.WriteLine(player.maxFood);
            sw.WriteLine(player.symbol);

            sw.Close();

            inGame = false;
        }
        void Load()
        {
            string savedPath = "saved.txt";
            StreamReader sr = new StreamReader(savedPath);

            CreateGame();

            for (int i = 0; i < map.yLength(); i++)
            {
                for (int j = 0; j < map.xLength(); j++)
                {
                    
                    switch (sr.Read())
                    {
                        case '*':
                        case 'O':
                            map.tiles[i, j] = new GameTile();
                            break;
                        case 'H':
                            map.tiles[i, j] = new HealTile();
                            break;
                        case 'F':
                            map.tiles[i, j] = new FoodTile();
                            break;
                        case 'T':
                            map.tiles[i, j] = new TrapTile();
                            break;
                    }
                }
            }

            map.tiles[map.yLength() - 1, map.xLength() - 1].symbol = 'O';

            sr.ReadLine();

            //Player
            string xxx = sr.ReadLine();
            player.xPos = int.Parse(xxx);
            player.yPos = int.Parse(sr.ReadLine());
            player.Name = sr.ReadLine();
            player.Turns = int.Parse(sr.ReadLine());
            player.HP = int.Parse(sr.ReadLine());
            player.maxHP = int.Parse(sr.ReadLine());
            player.Energy = int.Parse(sr.ReadLine());
            player.maxEnergy = int.Parse(sr.ReadLine());
            player.Food = int.Parse(sr.ReadLine());
            player.maxFood = int.Parse(sr.ReadLine());
            player.symbol = sr.ReadLine()[0];

            sr.Close();

            inGame = true;
        }

    }
}