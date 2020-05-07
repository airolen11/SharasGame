using System;

namespace SharasGame
{
    public class GameMap
    {
        GameTile[,] map { get; set; }

        public GameMap()
        {
            map = new GameTile[10, 10];
            GenerateNewMap();
            Render();
        }

        private void GenerateNewMap()
        {
            int x = map.GetLength(1); 
            int y = map.GetLength(0);
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

        public void Render()
        {
            int x = map.GetLength(1); Console.WriteLine(x);
            int y = map.GetLength(0); Console.WriteLine(y);

            Console.WriteLine();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.Write(map[i, j].symbol);
                }
                Console.Write("\n");
            }
            Console.WriteLine();
        }

    }
}