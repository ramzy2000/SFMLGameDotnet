using SFML.Graphics;
using SFML.System;
public class Game
{
    public static RenderWindow window = new RenderWindow(SFML.Window.VideoMode.DesktopMode, "Game");

    public static SystemManager systemManager = new SystemManager();

    public void Run()
    {
        window.Closed += CloseWindowHandel;
        Player player = new Player();
        Clock clock = new Clock();
        while(window.IsOpen)
        {
            window.DispatchEvents();

            float dt = clock.Restart().AsSeconds();

            window.Clear(Color.Black);

            systemManager.Update(dt);

            window.Display();
        }
    }

    public static void CloseWindowHandel(object? sender, EventArgs e)
    {
        window.Close();
    }
}
