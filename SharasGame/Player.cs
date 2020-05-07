using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class Player
    {
        public int xPos { get; set; }
        public int yPos { get; set; }
        public string Name { get; set; }
        public int HP { get; set; }
        public int maxHP { get; set; }
        public int Energy { get; set; }
        public int maxEnergy { get; set; }
        public int Food { get; set; }
        public int maxFood { get; set; }
        public char symbol { get; set; }

        public Player(Game game)
        {
            xPos = 0;
            yPos = 0;
            symbol = 'P';
            //INTERCHANGEABLE
            HP = 10;
            maxHP = 20;
            Energy = 10;
            maxEnergy = 20;
            Food = 15;
            maxFood = 30;
        }


    }
}
