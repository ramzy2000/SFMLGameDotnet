using SFML.Graphics;
public class GameState
{
    public static RenderWindow window = new RenderWindow(SFML.Window.VideoMode.DesktopMode, "Game");

    public static World world = new World();

    public static Level? currentLevel = null;

    public static float dt;

    public static void LoadLevel(Level level)
    {
        world.Reset();
        currentLevel = level;
        currentLevel.Load(world);
    }
}