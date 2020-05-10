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
        public int Turns { get; set; }
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
            Turns = 0;
            //INTERCHANGEABLE
            HP = 10;
            maxHP = 10;
            Energy = 5;
            maxEnergy = 5;
            Food = 8;
            maxFood = 10;
        }

        public void RenderStats()
        {
            Console.WriteLine($@"HP: {HP}/{maxHP}");
            Console.WriteLine($@"Food: {Food}/{maxFood}");
            Console.WriteLine($@"Energy: {Energy}/{maxEnergy}");
        }

        public void AdjustForDeficencies()
        {
            if(Energy <= 0 || Food <= 0)
            {
                setHP(-1);
            }

        }
        public bool isAlive()
        {
            return HP > 0;
        }
        public void setHP(int changeValue)
        {
            if(changeValue > 0)
            {
                HP = Math.Min(HP + changeValue, maxHP);
            }
            else
            {
                HP = Math.Max(HP+ changeValue, 0);
            }
        }
        public void setEnergy(int changeValue)
        {
            if (changeValue > 0)
            {
                Energy = Math.Min(Energy + changeValue, maxEnergy);
            }
            else
            {
                Energy = Math.Max(Energy + changeValue, 0);
            }
        }
        public void setFood(int changeValue)
        {
            if (changeValue > 0)
            {
                Food = Math.Min(Food + changeValue, maxFood);
            }
            else
            {
                Food = Math.Max(Food + changeValue, 0);
            }
        }
        public void addTurn()
        {
            Turns++;
        }
        public void Rest()
        {
            setEnergy(4);
            setFood(-1);
        }

        public int getScore()
        {
            return 100 + 2 * HP + 2 * Food + 3 * Energy - 3 * Turns;
        }
    }
}
