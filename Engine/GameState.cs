using SFML.Graphics;
public class GameState
{
    public static RenderWindow window = new RenderWindow(SFML.Window.VideoMode.DesktopMode, "Game");

    public static SystemManager systemManager = new SystemManager();

    public static Level? currentLevel = null;

    public static float dt;

    public static void LoadLevel(Level level)
    {
        currentLevel = level;
    }
}