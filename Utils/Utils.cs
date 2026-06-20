using SFML.System;

public class Utils
{
    public static float GetDistance(Vector2f a, Vector2f b)
    {
        return (float)Math.Sqrt(((a.X - a.X) * (b.X - b.X)) + ((a.Y - a.Y) * (b.Y - b.Y)));
    }
}