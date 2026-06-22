public class Program
{
    public static void Main(string[] args)
    {
        GameState.LoadLevel(new MainLevel());
        Game game = new Game();
        game.Run();
    }
}
