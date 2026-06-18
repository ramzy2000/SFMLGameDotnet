using SFML.System;
using SFML.Window;

public class InputComponent : Component
{
    public Vector2f direction = new Vector2f(0f, 0f);

    public float speed = 100.0f;

    public int walkAcceleration = 1;

    public TransformComponent transformComponent;

    public InputComponent(TransformComponent transformComponent)
    {
        this.transformComponent = transformComponent;
        InputSystem.Register(this);
    }

    public override void Update(float dt)
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

        // update the transform component
        transformComponent.position = transformComponent.position + direction * speed * dt;
    }
}