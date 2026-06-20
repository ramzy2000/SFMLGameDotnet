using SFML.System;

public class Utils
{
    public static float GetDistance(Vector2f a, Vector2f b)
    {
        return (float)Math.Sqrt(((a.X - a.X) * (b.X - b.X)) + ((a.Y - a.Y) * (b.Y - b.Y)));
    }

    public static Vector2f GetDirection(Vector2f from, Vector2f to)
    {
        Vector2f direction = to - from;
        float length = direction.Length();

        // Avoid division by zero
        if (length == 0f)
            return Vector2.Zero;

        return direction / length; // Normalized vector
    }
}