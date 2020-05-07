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
        public override void OnStep(Player player)
        {
            player.HP = 0;
        }
    }
}
