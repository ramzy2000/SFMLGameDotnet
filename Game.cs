using SFML.Graphics;
using SFML.System;
using SFML.Window;
public class Game
{
    public void Run()
    {
        GameState.window.Closed += CloseWindowHandel;
        Clock clock = new Clock();
        while(GameState.window.IsOpen)
        {
            GameState.window.DispatchEvents();

            GameState.dt = clock.Restart().AsSeconds();

            GameState.window.Clear(Color.Black);
            GameState.world.Update(GameState.dt);
            

            GameState.window.Display();
        }
    }

    public static void CloseWindowHandel(object? sender, EventArgs e)
    {
         GameState.window.Close();
    }
}
