using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class FoodTile : GameTile
    {
        public override void OnStep(Player player)
        {
            player.HP = player.maxHP; //HEAL TO FULL
        }
    }
}
