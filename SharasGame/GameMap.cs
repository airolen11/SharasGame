using System;

namespace SharasGame
{
    public class GameMap
    {
        public GameTile[,] tiles { get; set; }
        Game game;
        public GameMap(Game game)
        {
            this.game = game;
            tiles = new GameTile[10, 15];
            GenerateNewMap();
        }
        public bool ReactToStep(Player player)
        {
            if (player.xPos == xLength()-1 && player.yPos == yLength()-1)
            {
                game.OnVictory();
            }
            bool alive = tiles[player.yPos, player.xPos].OnStep(player);
            player.addTurn();
            tiles[player.yPos, player.xPos] = new GameTile();
            return alive;
        }
        private void GenerateNewMap()
        {
            int x = tiles.GetLength(0); 
            int y = tiles.GetLength(1);
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
                        tiles[i, j] = new GameTile();
                    }
                    else if (dice < 80)
                    {
                        tiles[i, j] = new TrapTile();
                    }
                    else if (dice < 90)
                    {
                        tiles[i, j] = new HealTile();
                    }
                    else 
                    {
                        tiles[i, j] = new FoodTile();
                    }
                }
            }

            //SAFEZONES
            tiles[0, 0] = new GameTile();
            tiles[1, 0] = new GameTile();
            tiles[1, 1] = new GameTile();
            tiles[0, 1] = new GameTile();

            tiles[x - 1, y - 1] = new GameTile();
            tiles[x - 1, y - 1].symbol = 'O';
            tiles[x - 2, y - 1] = new GameTile();
            tiles[x - 2, y - 2] = new GameTile();
            tiles[x - 1, y - 2] = new GameTile();

        }

        public string Render(Player player)
        {
            int x = tiles.GetLength(0);
            int y = tiles.GetLength(1);

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
                        Console.Write(tiles[i, j].symbol);
                    }
                }
                Console.Write("\n");
            }
            Console.WriteLine();
            return "";
        }
        public int yLength()
        {
            return tiles.GetLength(0);
        }
        public int xLength()
        {
            return tiles.GetLength(1);
        }

    }
}