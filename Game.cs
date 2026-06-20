using SFML.Graphics;
using SFML.System;
using SFML.Window;
public class Game
{
    public void Run()
    {
        GameState.window.Closed += CloseWindowHandel;
        Clock clock = new Clock();
        MainLevel mainLevel = new MainLevel();
        GameState.LoadLevel(mainLevel);
        while(GameState.window.IsOpen)
        {
            GameState.window.DispatchEvents();

            float dt = clock.Restart().AsSeconds();

            GameState.window.Clear(Color.Black);
            GameState.systemManager.Update(dt).Wait();

            GameState.window.Display();
        }
    }

    public static void CloseWindowHandel(object? sender, EventArgs e)
    {
         GameState.window.Close();
    }
}
