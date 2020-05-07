namespace SharasGame
{
    public class GameTile
    {
        public char symbol;

        public GameTile()
        {
            symbol = '*';
        }
        public virtual void OnStep(Player player)
        {
            player.Energy--;
            player.Food--;
        }

    }
}