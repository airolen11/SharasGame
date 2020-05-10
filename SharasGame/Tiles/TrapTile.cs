using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharasGame
{
    public class TrapTile : GameTile
    {

        public TrapTile()
        {
            symbol = 'T';
        }
        public override bool OnStep(Player player)
        {
            player.setHP(-3);
            player.setEnergy(-1);
            player.AdjustForDeficencies();
            return player.isAlive();
        }
    }
}
