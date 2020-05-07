using System;

namespace SharasGame
{
    public class Game
    {
        public static bool running;
        public GameMap map;
        public Player player;

        public Game(bool loadMap)
        {
            if (loadMap) throw new NotImplementedException();

            map = new GameMap();
        }

        public void Tick(string operation)
        {
            throw new NotImplementedException();
        }
        public void Render()
        {
            throw new NotImplementedException();
        }
        public void Save()
        {
            throw new NotImplementedException();
        }

    }
}