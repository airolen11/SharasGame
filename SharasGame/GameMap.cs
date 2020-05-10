using System;

namespace SharasGame
{
    public class GameMap
    {
        GameTile[,] map { get; set; }
        Game game;
        public GameMap(Game game)
        {
            this.game = game;
            map = new GameTile[10, 15];
            GenerateNewMap();
        }
        public bool ReactToStep(Player player)
        {
            if (player.xPos == xLength()-1 && player.yPos == yLength()-1)
            {
                game.OnVictory();
            }
            bool alive = map[player.yPos, player.xPos].OnStep(player);
            player.addTurn();
            map[player.yPos, player.xPos] = new GameTile();
            return alive;
        }
        private void GenerateNewMap()
        {
            int x = map.GetLength(0); 
            int y = map.GetLength(1);
            Random gen = new Random();

            //Randomizing tile types
            for (int i = 0; i < x; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < y; j++)
                {

                    //70pc base  10pc trap 10pc heal 10oc food
                    int dice = gen.Next(0, 100);
                    if(dice < 65)
                    {
                        map[i, j] = new GameTile();
                    }
                    else if (dice < 80)
                    {
                        map[i, j] = new TrapTile();
                    }
                    else if (dice < 90)
                    {
                        map[i, j] = new HealTile();
                    }
                    else 
                    {
                        map[i, j] = new FoodTile();
                    }
                }
            }

            //SAFEZONES
            map[0, 0] = new GameTile();
            map[1, 0] = new GameTile();
            map[1, 1] = new GameTile();
            map[0, 1] = new GameTile();

            map[x - 1, y - 1] = new GameTile();
            map[x - 2, y - 1] = new GameTile();
            map[x - 2, y - 2] = new GameTile();
            map[x - 1, y - 2] = new GameTile();

        }

        public string Render(Player player)
        {
            int x = map.GetLength(0);
            int y = map.GetLength(1);

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if(player.yPos == i && player.xPos == j)
                    {
                        Console.BackgroundColor = ConsoleColor.Yellow;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(player.symbol);
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write(map[i, j].symbol);
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return "";
        }
        public int yLength()
        {
            return map.GetLength(0);
        }
        public int xLength()
        {
            return map.GetLength(1);
        }

    }
}