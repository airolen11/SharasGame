namespace SharasGame
{
    public class GameTile
    {
        public char symbol;

        public GameTile()
        {
            symbol = '*';
        }
        public virtual bool OnStep(Player player)
        {
            player.setEnergy(-1);
            player.setFood(-1);
            player.AdjustForDeficencies();
            return player.isAlive();
        }

    }
}