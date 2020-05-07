namespace SharasGame
{
    public class GameTile
    {
        public char symbol;

        public GameTile()
        {
            symbol = '*';
        }
        public virtual void OnStep(Game game)
        {
            game.player.Energy--;
            game.player.Food--;
        }

    }
}