using SFML.System;
using SFML.Window;

public class InputComponent : Component
{
    public Vector2f direction = new Vector2f(0f, 0f);

    public float speed = 100.0f;

    public int walkAcceleration = 1;

    public Vector2f ReadMoveDirection()
    {
        direction = new Vector2f(0f, 0f);
        if (Keyboard.IsKeyPressed(Keyboard.Key.W))
        {
            direction.Y -= walkAcceleration;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.S))
        {
            direction.Y += walkAcceleration;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.A))
        {
            direction.X -= walkAcceleration;
        }

        if (Keyboard.IsKeyPressed(Keyboard.Key.D))
        {
            direction.X += walkAcceleration;
        }

        return direction;
    }

    public void CaptureInput()
    {
        Vector2f moveDirection = ReadMoveDirection();
        if (moveDirection.X == 0f && moveDirection.Y == 0f)
        {
            direction = moveDirection;
            return;
        }

        float length = MathF.Sqrt((moveDirection.X * moveDirection.X) + (moveDirection.Y * moveDirection.Y));
        direction = moveDirection / length;
    }
}