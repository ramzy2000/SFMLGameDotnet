using SFML.System;

public class Utils
{
    public static float GetDistance(Vector2f a, Vector2f b)
    {
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;
        return (float)Math.Sqrt((dx * dx) + (dy * dy));
    }
}