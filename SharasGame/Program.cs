using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = null;
            GameMenu menu = new GameMenu(ref game);
            Console.OutputEncoding = Encoding.Unicode;
            game.Loop();


        }
    }
}
