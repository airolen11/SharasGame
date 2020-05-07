using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class FoodTile : GameTile
    {

        public FoodTile()
        {
            symbol = 'F';
        }
        public override void OnStep(Game game)
        {
            game.player.Food = game.player.maxFood; //HEAL TO FULL
        }
    }
}
